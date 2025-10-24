using Dapper;
using ReadBookRepo.Base.IRepo;
using ReadBookRepo.Base.Param;
using ReadBookRepo.Entity.Manga;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using static Dapper.SqlMapper;
using MySqlConnector;


///viết code SQL động để insert vào DB bằng Dapper.
namespace ReadBookRepo.Base.Repo
{
    /// Repo base làm việc trực tiếp với DB (MySQL)
    public class MySqlBaseRepo<Entity, Dto> : IMySqlBaseRepo<Entity, Dto>
    {
        /// <summary>
        /// ConnectionString: chuỗi kết nối cố định tới database
        /// </summary>
        public const string _connectionString = "Server=localhost;Database=read_book;UserID=root;Password=2402;";

        /// <summary>
        /// Lấy toàn bộ dữ liệu 
        /// </summary>
        /// Author: NVTDuong 27.09.2025
        public async Task<List<Dto>> GetAll()
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            var tableName = GetNameTable();
            var sql = $"SELECT * FROM {tableName};";

            var result = await conn.QueryAsync<Dto>(sql);
            return result.AsList();
        }


        /// <summary>
        /// Truy vấn dữ liệu và map tự động vào DTO
        /// Author: NVTDuong 27.09.2025
        /// </summary>
        public async Task<List<T>> GetDataAsync<T>(MysqlParamBase paramBase = null)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            /// Nếu không truyền thì mặc định SELECT *
            if (paramBase == null)
            {
                paramBase = new MysqlParamBase
                {
                    column = "*",
                    param = null
                };
            }

            var sql = $"SELECT {paramBase.column} FROM {GetNameTable()};";

            var result = await conn.QueryAsync<T>(sql, paramBase.param);
            await conn.CloseAsync();
            return result.ToList();
        }

        /// <summary>
        /// Query dữ liệu có phân trang
        /// Author: NVTDuong 01.10.2025
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramPagingBase"></param>
        public async Task<MysqlResultPagingBase<T>> GetDataPagingAsync<T>(MysqlParamPagingBase paramPagingBase)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            /// Chọn ra các cột muốn lấy (ví dụ "*" hoặc "manga_id, manga_title")
            /// Lấy dữ liệu từ bảng, tên bảng được lấy bằng attribute [Table("manga")] trong Entity.
            var offset = (paramPagingBase.page - 1) * paramPagingBase.take;

            var sql = $@"SELECT {paramPagingBase.column} 
                 
                         FROM {GetNameTable()} 
                         LIMIT {offset}, {paramPagingBase.take};";

            var result = await conn.QueryAsync<T>(sql, paramPagingBase.param);
            await conn.CloseAsync();
            return new MysqlResultPagingBase<T>
            {
                data = result.ToList(),
                total_record = 0
            };
        }

        /// <summary>
        /// Lấy tên bảng từ [Table] attribute trong Entity
        /// </summary>
        /// Author: NVTDuong 27.09.2025
        /// <exception cref="Exception"></exception>
        private string GetNameTable()
        {
            try
            {
                // Lấy attribute [Table] của class
                var tableAttr = typeof(Entity)
                    .GetCustomAttribute<TableAttribute>();

                return tableAttr.Name;
            }
            catch
            {
                throw new Exception("Đm mày khai báo table cho tao");
            }
        }

        /// <summary>
        /// Thêm mới một dữ liệu vào database
        /// </summary>
        /// <param name="entity">Dữ liệu cần lưu</param>
        /// <returns></returns>
        /// Author: NVTDuong 27.09.2025
        public async Task<int> InsertAsync(Entity entity)
        {
            /// Lấy tên bảng từ attribute hoặc tên class
            var tableName = GetNameTable();
            /// Tìm property được đánh dấu [Key]
            var keyProp = typeof(Entity).GetProperties(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(p => Attribute.IsDefined(p, typeof(KeyAttribute)));

            // Nếu có property [Key] kiểu Guid và chưa có giá trị → tự sinh Guid
            if (keyProp != null && keyProp.PropertyType == typeof(Guid))
            {
                var current = (Guid)keyProp.GetValue(entity);
                /// Nếu chưa có giá trị (Guid.Empty = 0000…)
                if (current == Guid.Empty)
                {
                    /// Gán giá trị mới = Guid ngẫu nhiên
                    keyProp.SetValue(entity, Guid.NewGuid());
                }
            }

            /// Lấy tất cả property public (trừ những cái auto như Id nếu muốn)
            var props = typeof(Entity).GetProperties().Where(p => p.CanRead && p.GetValue(entity) != null);

            /// Ghép danh sách tên cột: "Name,Age,Address"
            var columns = string.Join(",", props.Select(p => p.Name));
            /// Ghép danh sách tham số: "@Name,@Age,@Address"
            var values = string.Join(",", props.Select(p => "@" + p.Name));

            /// Tạo câu SQL Insert động
            var sql = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

            /// Tạo kết nối MySQL
            using (var conn = new MySqlConnection(_connectionString))
            {
                /// Thực thi SQL bằng Dapper, truyền entity làm tham số
                return await conn.ExecuteAsync(sql, entity);
            }
        }

        /// <summary>
        ///  Cập nhật bản ghi theo khóa chính [Key] (UPDATE ... WHERE PK=@PK)
        /// </summary>
        /// <param name="entity"></param>
        /// Author: NVTDuong 27.09.2025
        /// <exception cref="Exception"></exception>
        public async Task<bool> UpdateAsync(Entity entity)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            /// Lấy tên bảng từ Entity (theo convention class = table)
            var tableName = GetNameTable();
            /// Tìm property được đánh dấu [Key] (khóa chính)
            var keyProp = typeof(Entity).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                           .FirstOrDefault(p => Attribute.IsDefined(p, typeof(KeyAttribute)));
            ///Nếu Entity không có [Key] → ném exception, vì không biết update bản ghi nào.
            if (keyProp == null)
                throw new Exception("Entity phải có property [Key] để làm WHERE clause");
            /// Lấy tất cả property của Entity
            /// p.CanRead → property có getter, nghĩa là bạn có thể đọc giá trị.
            /// p.GetValue(entity) != null → chỉ lấy những property có giá trị khác null.
            var properties = typeof(Entity).GetProperties()
                         .Where(p => p.CanRead && p.GetValue(entity) != null && p != keyProp)
                         .ToList();
            ///Tạo câu lệnh SET (col1=@col1, col2=@col2, ...)

            var setClause = string.Join(", ", properties.Select(p => $"{p.Name}=@{p.Name}"));

            /// Tạo câu lệnh UPDATE
            var sql = $"UPDATE {tableName} SET {setClause} WHERE {keyProp.Name}=@{keyProp.Name}";

            ///Thực thi câu lệnh
            var result = await conn.ExecuteAsync(sql, entity);

            await conn.CloseAsync();
            return result > 0; // số bản ghi được update
        }

        /// <summary>
        /// Xóa bản ghi theo khóa chính [Key] (DELETE ... WHERE PK=@PK)
        /// </summary>
        /// <param name="pkId"></param>
        /// Author: NVTDuong 27.09.2025
        /// <exception cref="Exception"></exception>
        public async Task<int> DeleteAsync(Guid pkId)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            /// Lấy tên bảng từ Entity (theo convention class = table)
            var tableName = GetNameTable();
            /// Tìm property được đánh dấu [Key] (khóa chính)
            var keyProp = typeof(Entity).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                           .FirstOrDefault(p => Attribute.IsDefined(p, typeof(KeyAttribute)));
            ///Nếu Entity không có [Key] → ném exception, vì không biết update bản ghi nào.
            if (keyProp == null)
                throw new Exception("Entity phải có property [Key] để làm WHERE clause");
            var sql = $"DELETE FROM {tableName} WHERE {keyProp.Name} = @{keyProp.Name}";

            var param = new Dictionary<string, object>
            {
                { $"@{keyProp.Name}", pkId }
            };

            var result = await conn.ExecuteAsync(sql, param);

            await conn.CloseAsync();
            return result; // số bản ghi được update
        }

        /// <summary>
        /// Hàm tổng số đối tượng
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountAsync()
        {
            var tableName = typeof(Entity).Name.Replace("Entity", "");

            var sql = $"SELECT COUNT(*) FROM {tableName.ToLower()}";

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteScalarAsync<int>(sql);
            }
        }

        public async Task<int> CountTodayAsync()
        {
            // Lấy tên bảng từ class Entity (VD: MangaEntity → manga)
            var tableName = typeof(Entity).Name.Replace("Entity", "");

            // Câu SQL đếm số bản ghi có created_date là ngày hôm nay
            var sql = $@"
                    SELECT COUNT(*) 
                    FROM {tableName.ToLower()}
                    WHERE DATE(created_date) = CURDATE();
                ";

            // Tạo kết nối đến MySQL
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteScalarAsync<int>(sql);
            }
        }
    }
}

