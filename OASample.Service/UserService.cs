using OASample.Repo.Converter;
using OASample.Data.Entity;
using OASample.Data.ViewModel;
using System.Collections.Generic;
using OASample.Repo.Repositories;
using AutoMapper;
using System.Linq;
using OASample.Repo.Extensions;

namespace OASample.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        private IRepository<User> userRepo => this.unitOfWork.GetRepository<User>();

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        //update
        public void AddUser(UserViewModel vm)
        {
            var entity = vm.MapToEntity();
            this.userRepo.Add(entity);
            this.unitOfWork.Commit();
        }

        //update
        public void UpdateUser(UserViewModel vm)
        {
            var entity = vm.MapToEntity();
            this.userRepo.Update(entity);
            this.unitOfWork.Commit();
        }

        public void DeleteUser(UserViewModel vm)
        {
            vm.IsActive = false;
            vm.IsRemoved = true;

            var entity = vm.MapToEntity();
            this.userRepo.Delete(entity);
            this.unitOfWork.Commit();
        }

        public IEnumerable<UserViewModel> MapToUserViewModel(IEnumerable<User> entity)
        {
            var result = this.mapper.Map<IEnumerable<UserViewModel>>(entity);
            return result;
        }

        //read
        public IEnumerable<UserViewModel> GetUsers()
        {
            return(this.MapToUserViewModel(this.userRepo.GetAll()));
        }

        public UserViewModel GetUserById(int id)
        {
            var result = this.userRepo.Where(x => x.Id == id).FirstOrDefault();
            return this.mapper.Map<UserViewModel>(result);
        }      
    }
}
