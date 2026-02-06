using CenterChangesManager.Common;
using CenterChangesManager.DAL;
namespace CenterChangesManager.BLL
{
    public class clsUser
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode { get; private set; } = enMode.AddNew;

        public User UserData { get; set; }

        // منشئ للمستخدم الجديد
        public clsUser()
        {
            this.UserData = new User { UserID = -1 };
            this.Mode = enMode.AddNew;
        }

        // منشئ خاص لتحميل بيانات موجودة
        private clsUser(User user)
        {
            this.UserData = user;
            this.Mode = enMode.Update;
        }

        // البحث
        public static async Task<clsUser?> FindAsync(int userID)
        {
            User? user = await clsUserData.GetUserByIDAsync(userID);
            return (user != null) ? new clsUser(user) : null;
        }

        // تسجيل الدخول
        public static async Task<clsUser?> LoginAsync(string userName, string password)
        {

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return null;

            User? user = await clsUserData.GetUserByUsernameAsync(userName);

            if (user == null)
            {
                return null;
            }

            bool IsVaildPassword = PasswordHasher.VerifyPassword
                (password, user.PasswordHash, user.PasswordSalt,
                user.ArgonMemorySize, user.ArgonIterations, user.ArgonParallelism);

            if (!IsVaildPassword)
            {
                return null;
            }

            return new clsUser(user);
        }

        // التحقق من الاسم
        public static async Task<bool> IsUserNameUsedAsync(string userName)
        {
            return await clsUserData.IsUserExistAsync(userName);
        }

        // الحفظ الذكي
        public async Task<bool> Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await IsUserNameUsedAsync(this.UserData.UserName))
                        throw new Exception("اسم المستخدم مكرر في النظام.");

                    this.UserData.UserID = clsUserData.AddNewUser(this.UserData);
                    if (this.UserData.UserID != -1)
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return clsUserData.UpdateUser(this.UserData);
            }
            return false;
        }

        public static bool DeleteAsync(int userID)
        {
            return clsUserData.DeleteUser(userID);
        }

        public static async Task<IEnumerable<clsUser>> GetAllUsersAsync()
        {
            var DataList = await clsUserData.GetAllUsersAsync();

            return


            DataList.Select(user => new clsUser(user)).ToList();
        }

        public static async Task<bool> IsAnyUserExistsAsync()
        {
            return await clsUserData.IsAnyUserExists();
        }







        public static clsUser CreateNew(UserRegisterData data)
        {
            PasswordHasher.CreatePasswordHash(data.Password, out string hash, out string salt, out int memory, out int iterations, out int parallelism);

            clsUser user = new clsUser();

            user.UserData.FullName = data.FullName;
            user.UserData.Permession = data.Permession;
            user.UserData.Email = data.Email;

            user.UserData.UserName = data.UserName;
            user.UserData.PasswordHash = hash;
            user.UserData.PasswordSalt = salt;
            user.UserData.ArgonMemorySize = memory;
            user.UserData.ArgonIterations = iterations;
            user.UserData.ArgonParallelism = parallelism;
            user.UserData.IsActive = true;

            // الباسورد انتهى
            data.Password = null;

            return user;
        }

    }
}