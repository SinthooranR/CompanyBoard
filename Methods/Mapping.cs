using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Methods
{
    public class Mapping
    {

        public Owner OwnerDtotoMain(OwnerDto ownerDto)
        {
            var owner = new Owner()
            {
                FirstName = ownerDto.FirstName,
                LastName = ownerDto.LastName,
                Phone = ownerDto.Phone,
                Address = ownerDto.Address,
                City = ownerDto.City,
                Country = ownerDto.Country,
                UserName = ownerDto.Email,
                Email = ownerDto.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                AccountStatus = true,
                Roles = ["Owner", "Admin"]
            };

            return owner;
        }

    }
}
