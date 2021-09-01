using Business.Commands.ResumeCommands;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.ResumeCommandHandlers
{
    public class UserResumeAddCommandHandler : IRequestHandler<UserResumeAddCommand, IResult>
    {
        private readonly IResumeDal _resumeDal;
        private readonly IUserDal _userDal;
        public UserResumeAddCommandHandler(IResumeDal resumeDal, IUserDal userDal)
        {
            _resumeDal = resumeDal;
            _userDal = userDal;
        }
        public async Task<IResult> Handle(UserResumeAddCommand request, CancellationToken cancellationToken)
        {
            if (request.ResumeFile == null) return new ErrorResult(Messages.ResumeFileIsEmpty);
            var result = await _userDal.Get(u => u.Id == request.UserId);
            if (result == null) return new ErrorResult(Messages.UserNotFound);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.ResumeFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "../RecapAPI/wwwroot/Resumes", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await request.ResumeFile.CopyToAsync(stream);
            }
            string resumePath = "https://localhost:44317/Resumes/" + fileName;
            result.ProfilPhotoUrl = resumePath;

            await _resumeDal.Add(new Resume {ResumeUrl= resumePath,UserId=request.UserId });

            return new SuccessResult(Messages.ResumeSuccesfulAdded);
        }
    }
}
