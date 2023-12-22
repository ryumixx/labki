﻿using AutoMapper;
using CompanyEmployees.ActionFilters;
using CompanyEmployees.ModelBinders;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api/grades")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public GradesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetGrades"), Authorize(Roles = "Teacher")]
        [HttpHead]
        public async Task<IActionResult> GetGrades()
        {
            var grades = await _repository.Grade.GetAllGradesAsync(trackChanges: false);
            var gradesDto = _mapper.Map<IEnumerable<GradeDto>>(grades);
            return Ok(gradesDto);
        }
        [HttpGet("{id}", Name = "GradeById")]
        public async Task<IActionResult> GetGrade(Guid id)
        {
            var grade = await _repository.Grade.GetGradeAsync(id, trackChanges: false);
            if (grade == null)
            {
                _logger.LogInfo($"Grade with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var gradeDto = _mapper.Map<GradeDto>(grade);
                return Ok(gradeDto);
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateGrade([FromBody] GradeForCreationDto grade)
        {
            var gradeEntity = _mapper.Map<Grade>(grade);
            _repository.Grade.CreateGrade(gradeEntity);
            await _repository.SaveAsync();
            var gradeToReturn = _mapper.Map<GradeDto>(gradeEntity);
            return CreatedAtRoute("GradeById", new { id = gradeToReturn.Id },
            gradeToReturn);
        }
        [HttpGet("collection/({ids})", Name = "GradeCollection")]
        public async Task<IActionResult> GetGradeCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }
            var gradeEntities = await _repository.Grade.GetByIdsAsync(ids, trackChanges: false);
            if (ids.Count() != gradeEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }
            var gradesToReturn =
           _mapper.Map<IEnumerable<GradeDto>>(gradeEntities);
            return Ok(gradesToReturn);
        }
        [HttpPost("collection")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateGradeCollection([FromBody] IEnumerable<GradeForCreationDto> gradeCollection)
        {
            var gradeEntities = _mapper.Map<IEnumerable<Grade>>(gradeCollection);
            foreach (var grade in gradeEntities)
            {
                _repository.Grade.CreateGrade(grade);
            }
            await _repository.SaveAsync();
            var gradeCollectionToReturn =
            _mapper.Map<IEnumerable<GradeDto>>(gradeEntities);
            var ids = string.Join(",", gradeCollectionToReturn.Select(c => c.Id));
            return CreatedAtRoute("GradeCollection", new { ids },
            gradeCollectionToReturn);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(Guid id)
        {
            var grade = await _repository.Grade.GetGradeAsync(id, trackChanges: false);
            if (grade == null)
            {
                _logger.LogInfo($"Grade with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Grade.DeleteGrade(grade);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateGradeExistsAttribute))]
        public async Task<IActionResult> UpdateGrade(Guid id, [FromBody] GradeForUpdateDto grade)
        {
            var gradeEntity = HttpContext.Items["grade"] as Grade;
            _mapper.Map(grade, gradeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
