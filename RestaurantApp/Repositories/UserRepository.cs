using System.Security.Cryptography;
using Entities;
using Repositories.Dbcontexts;
using Repositories.Interface;
using Repositories.Services;
using Repositories.Services.Exceptions;

namespace Repositories;
public class UserRepository : IRepository<User>
{
    //If we don't want to use the database we can just remove the dbcontext and and uncomment this after
    // comment the dbcontext and also the ones in program.cs and also by removing the dbcontxt also in the method

    /* private List<User> Users;

    public UserRepository(List<User> users)
    {
        Users = users;
    } */
    public RepositoryDbContext dbcontxt;

    public UserRepository(RepositoryDbContext dbcontxt)
    {
        this.dbcontxt = dbcontxt;
    }

    public void Delete(int id)
    {
        var item = GetOne(id);
        if (item is null)
        {
            // return;
            throw new NotFoundException(id);
        }
        dbcontxt.Users.Remove(item);
        dbcontxt.SaveChanges();
    }

    public User GetOne(int id)
    {
       return dbcontxt.Users.Where(user=>user.Id==id).SingleOrDefault();
    }

    public void Post(User item)
    {
       if (item is null)
       {
         throw new UserRegisterBadRequestException("You can't add an empty elemant");
       }
       var salt = RandomNumberGenerator.GetInt32(1000);
       var pass = item.Password.Encoder(salt);
       item.Salt=salt;
       item.Password=pass;
       dbcontxt.Users.Add(item);
       dbcontxt.SaveChanges();
    }
    public User GetData(string email,string password){
        var item = dbcontxt.Users.Where(u=>u.Email==email).SingleOrDefault();
        if (item is null)
        {
            throw new UserLoginBadRequestException($"The email: {email} is not found!!!");
        }
        if (item.Password==password.Encoder(item.Salt))
        {
            return item;
        }
        throw new UserLoginBadRequestException();
    }
}