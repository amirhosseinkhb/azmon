using Azmon.Application.Services.Question.Commands.AddNewCategory;
using Azmon.Application.Services.Question.Commands.AddNewQuestion;
using Azmon.Application.Services.Question.Queries.GetAllCategories;
using AzmonNew.Application.Interface.Contexts;
using AzmonNew.Application.Interface.FacadPatterns;
using AzmonNew.Application.Services.Questions.Commands.AddNewQuestionPack;
using AzmonNew.Application.Services.Questions.Commands.AddQuestionToAzmon;
using AzmonNew.Application.Services.Questions.Commands.EditQuestion;
using AzmonNew.Application.Services.Questions.Commands.RemoveCategory;
using AzmonNew.Application.Services.Questions.Commands.RemoveQuestion;
using AzmonNew.Application.Services.Questions.Queries.GetAzmonForAdmin;
using AzmonNew.Application.Services.Questions.Queries.GetQuestionDetailForAdmin;
using AzmonNew.Application.Services.Questions.Queries.GetQuestionForAdmin;
using AzmonNew.Application.Services.User.Queries.GetUsers;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Azmon.Application.Services.Question.FacadPattern
{
    public class QuestionFacad : IQuestionFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public QuestionFacad(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private AddNewCategoryService _addNewCategoryService;
        public AddNewCategoryService addNewCategoryService
        {
            get
            {
                return _addNewCategoryService = _addNewCategoryService ?? new AddNewCategoryService(_context);
            }
        }

        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService getAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }

        private AddNewQuestionService _addNewQuestionService;
        public AddNewQuestionService addNewQuestionService
        {
            get
            {
                return _addNewQuestionService = _addNewQuestionService ?? new AddNewQuestionService(_context, _environment);
            }
        }

        private IGetQuestionForAdminService _getQuestionForAdminService;
        public IGetQuestionForAdminService getQuestionForAdminService
        {
            get { return _getQuestionForAdminService = _getQuestionForAdminService ?? new GetQuestionForAdminService(_context); }
        }

        private RemoveQuestionService _removeQuestionService;
        public RemoveQuestionService removeQuestionService
        {
            get { return _removeQuestionService = _removeQuestionService ?? new RemoveQuestionService(_context); }

        }

        private RemoveCategoryService _removeCategoryService;
        public RemoveCategoryService removeCategoryService
        {
            get
            {
                return _removeCategoryService = _removeCategoryService ?? new RemoveCategoryService(_context);
            }
        }

        private EditQuestionService _editQuestionService;
        public EditQuestionService editQuestionService
        {
            get
            {
                return _editQuestionService = _editQuestionService ?? new EditQuestionService(_context);
            }
        }

        private AddNewQuestionPackService _addNewQuestionPackService;
        public AddNewQuestionPackService addNewQustionPackService
        {
            get
            {
                return _addNewQuestionPackService = _addNewQuestionPackService ?? new AddNewQuestionPackService(_context);
            }
        }

        private IGetQuestionDetailsForAdminServuce _getQuestionDetailsForAdminServuce;
        public IGetQuestionDetailsForAdminServuce getQuestionDetailsForAdminServuce
        {
            get
            {
                return _getQuestionDetailsForAdminServuce= _getQuestionDetailsForAdminServuce ??new GetQuestionDetailsForAdminServuce(_context);
            }
        }

        private IGetAllAzmonForAdmin _getAllAzmonForAdmin;
        public IGetAllAzmonForAdmin getAllAzmon
        {
            get { return _getAllAzmonForAdmin = _getAllAzmonForAdmin ??new GetAllAzmonForAdmin(_context); }
        }

        private AddQuestionToAzmonService _addQuestionToAzmonService;
        public AddQuestionToAzmonService AddQuestionToAzmon
        {
            get
            {
                return _addQuestionToAzmonService = _addQuestionToAzmonService ?? new AddQuestionToAzmonService(_context);
            }
        }
    }
}
