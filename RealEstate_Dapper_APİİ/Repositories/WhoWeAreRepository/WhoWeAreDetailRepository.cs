﻿using Dapper;
using RealEstate_Dapper_APİİ.Dtos.CategoryDtos;
using RealEstate_Dapper_APİİ.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_APİİ.Models.DapperContext;

namespace RealEstate_Dapper_APİİ.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {

        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail (Title,Subtitle,Description1,Description2) values(@title,@subTitle,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetailDto.Title);
            parameters.Add("@subTitle", createWhoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", createWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", createWhoWeAreDetailDto.Description2);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {

            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailID=@WhoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@WhoWeAreDetailID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoWeAreDetail where WhoWeAreDetailID=@WhoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@WhoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "Update WhoWeAreDetail Set Title=@title,Subtitle=@subTitle,Description1=@description1,Description2=@description2 where WhoWeAreDetailID=@WhoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDetailDto.Title);
            parameters.Add("@subTitle", updateWhoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", updateWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", updateWhoWeAreDetailDto.Description2);
            parameters.Add("@whoWeAreDetailID", updateWhoWeAreDetailDto.WhoWeAreDetailID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
