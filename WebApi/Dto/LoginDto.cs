using Azure.Identity;
namespace WebApi.Dto;

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}