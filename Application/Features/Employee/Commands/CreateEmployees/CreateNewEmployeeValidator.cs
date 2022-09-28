using Application.DTOs.ResultDto;
using Utilities.Helpers;

namespace Application.Features.Employee.Commands.CreateEmployees
{
    public class CreateNewEmployeeValidator
    {
        public static ValidRequestResult ValidCreateNewEmployeeRequest(CreateNewEmployeeCommand request)
        {
            string message = "";
            bool flag = true;
            if (string.IsNullOrEmpty(request.EmployeeInfo.FullName))
            {
                flag = false;
                message += "FullName is required, ";
            }

            if (string.IsNullOrEmpty(request.EmployeeInfo.DoB.ToString()) || Validations.IsDateTimeNullorEmpty(request.EmployeeInfo.DoB))
            {
                flag = false;
                message += "DoB is required, ";
            }

            if (string.IsNullOrEmpty(request.EmployeeInfo.Email))
            {
                flag = false;
                message += "Email is required, ";
            }

            if (string.IsNullOrEmpty(request.EmployeeInfo.PhoneNumber))
            {
                flag = false;
                message += "PhoneNumber is required, ";
            }

            if (request.Image == null)
            {
                flag = false;
                message += "Image is required";
            }

            if (string.IsNullOrEmpty(request.EmployeeInfo.TitleId.ToString()))
            {
                flag = false;
                message += "TitleId is required";
            }

            if (string.IsNullOrEmpty(request.EmployeeInfo.DepartmentId.ToString()))
            {
                flag = false;
                message += "DepartmentId is required";
            }

            if (string.IsNullOrEmpty(request.EmployeeInfo.ModeId.ToString()))
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
