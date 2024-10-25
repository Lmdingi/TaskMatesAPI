using AutoMapper;
using DataAccess.Repository.Interfaces;
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

        public DemoEmailListService(IDemoEmailListsDbSet demoEmailListsDb, IMapper mapper)
        {
            _demoEmailListsDb = demoEmailListsDb;
            _mapper = mapper;
        }
        public async Task<List<DemoEmailList>?>? GetAllAsync()
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
    }
}
