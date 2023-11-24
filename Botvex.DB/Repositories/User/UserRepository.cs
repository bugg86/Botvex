using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Models.User;
using Botvex.DB.Repositories.User.Interfaces;

namespace Botvex.DB.Repositories.User;

public class UserRepository : Repository<UserExtended>, IUserRepository
{
    public UserRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}