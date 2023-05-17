﻿using Microsoft.Extensions.Configuration;
using Project.GrateFulDonors.Core.Common;
using Project.GrateFulDonors.Core.Models;
using Project.GrateFulDonors.Core;
using Project.GrateFulDonors.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.GrateFulDonors.Services
{
    public class SeekerService : ISeekerService
    {
        private readonly IGrateFulDonorsUnitOfWork UnitOfWork;
        private readonly IGrateFulDonorsResponse GrateFulDonorsResponse;
        private readonly IConfiguration configuration;

        public SeekerService(IGrateFulDonorsUnitOfWork UnitOfWork, IGrateFulDonorsResponse GrateFulDonorsResponse, IConfiguration configuration)
        {
            this.GrateFulDonorsResponse = GrateFulDonorsResponse;
            this.UnitOfWork = UnitOfWork;
            this.configuration = configuration;
        }
        public async Task<GrateFulDonorsResponse> GetAllSeekerLength()
        {
            try
            {
                var result = await UnitOfWork.Repository<GetSeekerLengthModel>().GetEntitiesBySPAsyncWithoutParameters("[Administration].[GetAllSeekerLength]");
                return GrateFulDonorsResponse.GenerateResponseMessage(GrateFulDonorsResponseEnum.Success.ToString(), string.Empty, result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
