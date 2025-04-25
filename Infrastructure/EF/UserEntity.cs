using BackendApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.EF;

public class UserEntity : IdentityUser
{
    public UserDetails Details { get; set; }
    
}