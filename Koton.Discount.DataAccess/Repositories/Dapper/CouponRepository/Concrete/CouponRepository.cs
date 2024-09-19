using System.Data;
using Dapper;
using Koton.Discount.DataAccess.Repositories.Dapper.CouponRepository.Abstract;
using Koton.Discount.Entity.Entities.Concrete;

namespace Koton.Discount.DataAccess.Repositories.Dapper.CouponRepository.Concrete
{
    public class CouponRepository(IDbConnection dbConnection) : ICouponRepository
    {
        

        public async Task<List<Coupon>> GetAllAsync()
        {
            var query = "SELECT * FROM Coupons";
            var result = await dbConnection.QueryAsync<Coupon>(query);
            return result.ToList();
        }


        public async Task<Coupon> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Coupons WHERE Id = @Id";
            return await dbConnection.QuerySingleOrDefaultAsync<Coupon>(query, new { Id = id });
        }

        public async Task AddAsync(Coupon entity)
        {
            var query = "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate)";
            await dbConnection.ExecuteAsync(query, entity);
        }


        public async Task UpdateAsync(int id, Coupon entity)
        {
            var query = "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE Id = @Id";
            await dbConnection.ExecuteAsync(query, new { entity.Code, entity.Rate, entity.IsActive, entity.ValidDate, Id = id });
        }

        public async Task DeleteAsync(int id)
        {
            var query = "DELETE FROM Coupons WHERE Id = @Id";
            await dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}