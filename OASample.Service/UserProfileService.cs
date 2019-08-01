using OASample.Data.Entity;
using OASample.Repo.Repositories;

namespace OASample.Service
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork unitOfWork;

        private IRepository<UserProfile> userProfileRepo => this.unitOfWork.GetRepository<UserProfile>();

        public UserProfileService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(UserProfile entity)
        {
            this.userProfileRepo.Add(entity);
            this.unitOfWork.Commit();
        }

        public void Update(UserProfile entity)
        {
            this.userProfileRepo.Update(entity);
            this.unitOfWork.Commit();
        }
    }
}
