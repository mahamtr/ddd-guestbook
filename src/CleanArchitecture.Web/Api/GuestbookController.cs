﻿using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Api
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class GuestbookController : Controller
    {
        private readonly IRepository _repository;

        public GuestbookController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var guestbook = _repository.GetById<Guestbook>(id);
            if (guestbook == null)
            {
                return NotFound(id);
            }
            var entries = _repository.List<GuestbookEntry>();
            guestbook.Entries.Clear();
            guestbook.Entries.AddRange(entries);
            return Ok(guestbook);
        }
    }
}
