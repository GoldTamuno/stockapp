﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAppSQ20.Dtos.Email;
using StockAppSQ20.Interfaces;

namespace StockAppSQ20.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}
