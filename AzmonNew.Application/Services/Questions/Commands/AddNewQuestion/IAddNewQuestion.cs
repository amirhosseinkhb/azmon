using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Common.Dto;
using AzmonNew.Domain.Entities.Questions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;


namespace Azmon.Application.Services.Question.Commands.AddNewQuestion
{
    public interface IAddNewQuestionService
    {
        ResultDto Execute(RequestAddNewQuestonDto request);
    }


    public class AddNewQuestionService : IAddNewQuestionService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public AddNewQuestionService(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public ResultDto Execute(RequestAddNewQuestonDto request)
        {
            try
            {
                var category = _context.Categories.Find(request.CategoryId);
                var question = new AzmonNew.Domain.Entities.Questions.Question()
                {
                    Category = category,
                    QuestionText = request.QuestionText,
                    level = request.level,
                };


                _context.Questions.Add(question);

                List<QuestionImage> QuestionImages = new List<QuestionImage>();
                foreach (var item in request.Images)
                {
                    var uploadedResult = UploadFile(item);
                    QuestionImages.Add(new QuestionImage
                    {
                        Question = question,
                        Src = uploadedResult.FileNameAddress,
                    });
                }

                _context.QuestionImages.AddRange(QuestionImages);

                if (request.Options.Count == 0)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "لطفا گزینه ها را وارد کنید"
                    };
                }

                List<QuestionOption> QuestionOption = new List<QuestionOption>();
                foreach (var item in request.Options)
                {
                    QuestionOption.Add(new QuestionOption
                    {
                        Question = question,
                        isTrue = item.isTrue,
                        text = item.text,
                    });
                }
                
                _context.QuestionOptions.AddRange(QuestionOption);

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "سوال با موفقیت به سوالات اضافه شد",
                };


            }
            catch (Exception e)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد ",
                };
            }
        }


        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }
    public class UploadDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }





    public class RequestAddNewQuestonDto
    {

        public string QuestionText { get; set; }
        public int CategoryId { get; set; }
        public int level { get; set; }
        public List<IFormFile> Images { get; set; }
        public virtual List<AddNewQuestion_Option> Options { get; set; }

    }

    public class AddNewQuestion_Option
    {
        public string text { get; set; }
        public bool isTrue { get; set; }
    }
}
