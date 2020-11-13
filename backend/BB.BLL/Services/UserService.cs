﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BB.BLL.Interfaces;
using BB.BLL.Services.Abstract;
using BB.Common.Dto;
using BB.DAL.Context;
using BB.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BB.BLL.Services
{
    public class UserService : BaseService, IUserService 
    {
        public UserService(BBContext context, IMapper mapper) : base(context, mapper) { } 
        
        public async Task<UserDto> GetUserById(int id)
        {
            var user = await Context.Users.AsNoTracking()
                .FirstAsync(u => u.UserId == id);
            
            return Mapper.Map<UserDto>(user);
        }
        
        public async Task<UserDto> GetUserByCardId(int cardId)
        {
            var user = (await  Context.Cards.AsNoTracking()
                .Include(c => c.User)
                .Where(c => c.CardId == cardId)
                .FirstOrDefaultAsync())?.User;
            
            return Mapper.Map<UserDto>(user);
        }
        
        public async Task<ReadOnlyCollection<UserDto>> GetAll()
        {
            var users = await Context.Users.AsNoTracking()
                .ToListAsync();
            
            return Mapper.Map<ReadOnlyCollection<UserDto>>(users);
        }
    }
}