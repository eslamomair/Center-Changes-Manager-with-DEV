using Dapper.Contrib.Extensions;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace CenterChangesManager.Common
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }
        public int Permession { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }


        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public int ArgonMemorySize { get; set; }
        public int ArgonIterations { get; set; }
        public int ArgonParallelism { get; set; }

    }
    public class UserLoginData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserRegisterData
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Permession { get; set; }
    }

    public static class PasswordHasher
    {

        public static void CreatePasswordHash(string Password,
            out string hash, out string salt, out int memory, out int intreations, out int parallelism)
        {
            memory = 19456; // 19m
            intreations = 2;
            parallelism = 1;

            byte[] saltBytes = RandomNumberGenerator.GetBytes(16);

            Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(Password))
            {
                Salt = saltBytes,
                MemorySize = memory,
                Iterations = intreations,
                DegreeOfParallelism = parallelism
            };

            byte[] hashBytes = argon2.GetBytes(32);

            hash = Convert.ToBase64String(hashBytes);
            salt = Convert.ToBase64String(saltBytes);
        }
        //اعاده توليد كلمه السر 
        private static string HashPassword(
    string password,
    string base64Salt,
    int memory,
    int iterations,
    int parallelism)
        {


            byte[] saltBytes = Convert.FromBase64String(base64Salt);

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = saltBytes,
                MemorySize = memory,
                Iterations = iterations,
                DegreeOfParallelism = parallelism
            };

            byte[] hashBytes = argon2.GetBytes(32);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(
      string password,
      string storedHash,
      string storedSalt,
      int memory,
      int iterations,
      int parallelism)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            string computedHash = HashPassword(
                password,
                storedSalt,
                memory,
                iterations,
                parallelism
            );

            return CryptographicOperations.FixedTimeEquals(
                Convert.FromBase64String(computedHash),
                Convert.FromBase64String(storedHash)
            );
        }

    }
}
