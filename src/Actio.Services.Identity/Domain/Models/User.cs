﻿using System;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Services;

namespace Actio.Services.Identity.Domain.Models
{
    public class User
    {
        protected User()
        {
        }

        public User(string email, string name)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ActioException("empty_user_email", "User email cannot be empty");
            if (string.IsNullOrWhiteSpace(name))
                throw new ActioException("empty_user_name", "User name cannot be empty");

            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ActioException("empty_password", "Password cannot be empty");
            Salt = encrypter.GetSalt();
            Password = encrypter.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
        {
            return Password.Equals(encrypter.GetHash(password, Salt));
        }
    }
}