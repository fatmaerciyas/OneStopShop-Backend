using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer.DTOs.LogDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LogManager : ILogService
    {
        private readonly Context _context;

        public LogManager(Context context)
        {
            _context = context;
        }

        public async Task SaveNewLog(string UserName, string Description)
        {
            var newLog = new Log()
            {
                UserName = UserName,
                Description = Description
            };

            await _context.Logs.AddAsync(newLog);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<GetLogDto>> GetLogsAsync()
        {
            var logs =  _context.Logs
                 .Select(q => new GetLogDto
                 {
                     CreatedAt = q.CreatedAt,
                     Description = q.Description,
                     UserName = q.UserName,
                 })
                 .OrderByDescending(q => q.CreatedAt)
                 .ToList();
            return logs;
        }

        public async Task<IEnumerable<GetLogDto>> GetMyLogsAsync(ClaimsPrincipal User)
        {
            var logs =  _context.Logs
                .Where(q => q.UserName == User.Identity.Name)
               .Select(q => new GetLogDto
               {
                   CreatedAt = q.CreatedAt,
                   Description = q.Description,
                   UserName = q.UserName,
               })
               .OrderByDescending(q => q.CreatedAt)
               .ToList();
            return logs;
        }
    }
}
