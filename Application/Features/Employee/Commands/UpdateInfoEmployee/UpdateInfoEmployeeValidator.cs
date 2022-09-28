using Application.DTOs.ResultDto;
using Utilities.Helpers;

namespace Application.Features.Employee.Commands.UpdateInfoEmployee
{
    public class UpdateInfoEmployeeValidator
    {
        public static ValidRequestResult ValidUpdateInfoEmployeeRequest(UpdateInfoEmployeeCommand request)
        {
            string message = "";
            bool flag = true;
            if (string.IsNullOrEmpty(request.Id.ToString()))
            {
                flag = false;
                message += "Id is required";
            }

            if (string.IsNullOrEmpty(request.FullName))
            {
                flag = false;
                message += "FullName is required";
            }

            if (string.IsNullOrEmpty(request.DoB.ToString()) || Validations.IsDateTimeNullorEmpty(request.DoB))
            {
                flag = false;
                message += "DoB is required, ";
            }

            if (string.IsNullOrEmpty(request.Email))
            {
                flag = false;
                message += "Email is required, ";
            }

            if (string.IsNullOrEmpty(request.PhoneNumber))
            {
                flag = false;
                message += "PhoneNumber is required, ";
            }

            if (request.Image == null)
            {
                flag = false;
                message += "Image is required";
            }

            if (string.IsNullOrEmpty(request.TID.ToString()))
            {
                flag = false;
                message += "TitleId is required";
            }

            if (string.IsNullOrEmpty(request.DID.ToString()))
            {
                flag = false;
                message += "DepartmentId is required";
            }

            if (string.IsNullOrEmpty(request.MID.ToString()))
            {
                flag = false;
                message += "ModeId is required";
            }

            if (flag == false)
                return new ValidRequestResult { isValid = flag, Message = message };

            return new ValidRequestResult { isValid = flag, Message = "" };
        }
    }
}
