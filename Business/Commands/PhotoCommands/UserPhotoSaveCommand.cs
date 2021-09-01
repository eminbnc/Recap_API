using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commands.PhotoCommands
{
    public class UserPhotoSaveCommand : IRequest<IResult>
    {
        public IFormFile ImageFile { get; }
        public int Id { get; set; }
        public UserPhotoSaveCommand(IFormFile imageFile,int id)
        {
            ImageFile = imageFile;
            Id = id;
        }
    }
}
