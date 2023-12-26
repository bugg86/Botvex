using Botvex.DB.Contexts.Interfaces;
using Botvex.DB.Repositories.User.Interfaces;

namespace Botvex.DB.Repositories.User;

public class UserRepository : Repository<Models.User>, IUserRepository
{
    public UserRepository(IBotvexContext botvexContext) : base(botvexContext)
    {
        
    }
}