﻿namespace Programming008.Identity01.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
    }
}
