﻿using ProfileApp.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.Dto.TblUserDtos
{
    public class TblUserUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public Guid UserNamGuidId { get; set; }
        public string MailAdress { get; set; }

        public int StatusId { get; set; }
    }
}