using Azmon.Application.Services.Question.Commands.AddNewCategory;
using Azmon.Application.Services.Question.Commands.AddNewQuestion;
using Azmon.Application.Services.Question.Queries.GetAllCategories;
using AzmonNew.Application.Services.Questions.Commands.AddNewQuestionPack;
using AzmonNew.Application.Services.Questions.Commands.AddQuestionToAzmon;
using AzmonNew.Application.Services.Questions.Commands.DeleteAzmon;
using AzmonNew.Application.Services.Questions.Commands.EditQuestion;
using AzmonNew.Application.Services.Questions.Commands.EmptyAzmon;
using AzmonNew.Application.Services.Questions.Commands.RemoveCategory;
using AzmonNew.Application.Services.Questions.Commands.RemoveQuestion;
using AzmonNew.Application.Services.Questions.Queries.GetAzmonForAdmin;
using AzmonNew.Application.Services.Questions.Queries.GetQuestionDetailForAdmin;
using AzmonNew.Application.Services.Questions.Queries.GetQuestionForAdmin;
using AzmonNew.Application.Services.User.Queries.GetUsers;

namespace AzmonNew.Application.Interface.FacadPatterns
{
    public interface IQuestionFacad
    {
        AddNewCategoryService addNewCategoryService { get; }
        IGetAllCategoriesService getAllCategoriesService { get; }
        AddNewQuestionService addNewQuestionService { get; }
        IGetQuestionForAdminService getQuestionForAdminService { get; }
        RemoveQuestionService removeQuestionService { get; }
        RemoveCategoryService removeCategoryService { get; }
        EditQuestionService editQuestionService { get; }
        AddNewQuestionPackService addNewQustionPackService { get; }
        IGetQuestionDetailsForAdminServuce getQuestionDetailsForAdminServuce { get; }
        IGetAllAzmonForAdmin getAllAzmon { get; }
        AddQuestionToAzmonService AddQuestionToAzmon { get; }
        EmptyAzmonService EmptyAzmon { get; }
        DeleteAzmonService deleteAzmonService { get; }

    }
}
