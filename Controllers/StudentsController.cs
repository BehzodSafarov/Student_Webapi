using Microsoft.AspNetCore.Mvc;
using StudentWebapi.DTOs;

namespace StudentWebapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController:ControllerBase
{
 [HttpGet]
 public IActionResult GetStudents()
 {
    var studens=StudentDTOs.students;
    if(!studens.Any())
    {
        return NoContent();
    }
    else
    {
      return(Ok(studens));
    }
  }

  [HttpGet]
  [Route("{Id}")]
  public IActionResult GetStudent(Guid id)
  {
    var student=StudentDTOs.students.Find(x=>x.Id==id);
    if(student is null)
    {
        return NoContent();
    }
    else
    {
        return Ok(student);
    }
  }

  [HttpPost]
 public IActionResult PostStudent(StudentDTOs studentDTO)
 {
  studentDTO.Id=Guid.NewGuid();
  StudentDTOs.students.Add(studentDTO);
  return Created("Successefuly created",studentDTO);

 }
 [HttpDelete]
    [Route("{Id}")]
    public IActionResult DeleteStudentById(Guid Id)
    {
        var student=StudentDTOs.students.Find(s=>s.Id==Id);
        if(student is not StudentDTOs)
        {
            return NotFound();
        }
        StudentDTOs.students.Remove(student);
        return Ok("Successfully deleted");
    }
    
    [HttpPut]
    public IActionResult UpdateStudent(StudentDTOs student)
    {
        var studentDTO=StudentDTOs.students.Find(s=>s.Id==student.Id);
        if(studentDTO is not StudentDTOs)
        {
            return NotFound();
        }
        StudentDTOs.students.Remove(studentDTO);
        StudentDTOs.students.Add(student);
        return Ok("Successfully updated");
    }
    

}