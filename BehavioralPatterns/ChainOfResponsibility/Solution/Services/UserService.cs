using ChainOfResponsibility.Solution.Models;

namespace ChainOfResponsibility.Solution.Services
{
    public static class UserService
    {
        private static readonly List<User> Users = 
        [
            new(new("0A2A2FF2-B055-4608-9B41-32BCCA2907A4"), "David", 14, true, false),
            new(new("E2E651BF-3245-4844-BECC-40F852E4DC57"), "Peter", 12, true, false),
            new(new("63065E30-94AE-4CCD-9FD6-123E6E02BEA3"), "Marlon", 17, true, true),
            new(new("66F88FD6-9611-45C7-ACFB-B6991978C1FF"), "William", 18, false, false),
        ];
        public static async Task<User?> GetByIdAsync(Guid id)
        {
            await Task.Delay(100);
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public static async Task<List<(Guid Id, string Name)>> ListAsync()
        {
            await Task.Delay(100);
            return Users.Select(u => (u.Id, u.Name)).ToList();
        }

        public static async Task<bool> BanUser(Guid id, bool banned)
        {
            await Task.Delay(100);
            var user = Users.FirstOrDefault(x => x.Id == id);
            if (user == null) return false;

            bool wasActive = user.IsActive;

            user.IsActive = !banned;

            return wasActive == banned;
        }
    }
}
