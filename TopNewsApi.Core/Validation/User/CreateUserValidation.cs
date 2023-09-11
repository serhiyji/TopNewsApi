﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.DTOs.User;

namespace TopNewsApi.Core.Validation.User
{
    public class CreateUserValidation : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidation()
        {
            RuleFor(r => r.FirstName).NotEmpty().MinimumLength(2).MaximumLength(128);
            RuleFor(r => r.LastName).NotEmpty().MinimumLength(2).MaximumLength(128);
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Role).NotEmpty();
            RuleFor(r => r.Password).NotEmpty().MinimumLength(6);
            RuleFor(r => r.ConfirmPassword).NotEmpty().MinimumLength(6).Equal(p => p.Password);
        }
    }
}
