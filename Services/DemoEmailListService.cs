using AutoMapper;
using DataAccess.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DemoEmailListService : IDemoEmailListService
    {
        private readonly IDemoEmailListsDbSet _demoEmailListsDb;
        private readonly IMapper _mapper;
        private readonly ILogger<DemoEmailListService> _logger;

        public DemoEmailListService(IDemoEmailListsDbSet demoEmailListsDb, IMapper mapper, ILogger<DemoEmailListService> logger)
        {
            _demoEmailListsDb = demoEmailListsDb;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<DemoEmailList>?>? GetAllAsync()
        {
            try
            {               
                var emails = await _demoEmailListsDb.GetAllAsync();

                if (emails == null)
                {
                    return null;
                }

                List<DemoEmailList> mappedEmails = new();

                foreach (var email in emails)
                {
                    var mappedEmail = _mapper.Map<DemoEmailList>(email);
                    mappedEmails.Add(mappedEmail);
                }

                return mappedEmails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}
