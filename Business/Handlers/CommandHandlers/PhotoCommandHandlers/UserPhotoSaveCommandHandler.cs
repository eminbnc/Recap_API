using Business.Commands.PhotoCommands;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.PhotoCommandHandlers
{
    public class UserPhotoSaveCommandHandler : IRequestHandler<UserPhotoSaveCommand, IResult>
    {
        private readonly IUserDal _userDal;
        public UserPhotoSaveCommandHandler(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<IResult> Handle(UserPhotoSaveCommand request, CancellationToken cancellationToken)
        {
            if (request.ImageFile == null) return new ErrorResult(Messages.PhotoFileIsEmpty);
            var result = await _userDal.Get(u => u.Id == request.Id);
            if (result == null) return new ErrorResult(Messages.UserNotFound);
            
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.ImageFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "../RecapAPI/wwwroot/Images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await request.ImageFile.CopyToAsync(stream);
            }
            string ImagePath = "https://localhost:44355/Images/" + fileName;
            result.ProfilPhotoUrl = ImagePath;
            
            await _userDal.Update(result);
          
            return new SuccessResult(Messages.PhotoSuccesfulUpdated);
        }
    }
}
