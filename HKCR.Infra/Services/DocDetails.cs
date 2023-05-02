using HKCR.Application.Common.DTO.Document;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;

namespace HKCR.Infra.Services;

public class DocDetails : IDocDetails
{
    private readonly IApplicationDbContext _dbContext;

    public DocDetails(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<DocResponseDto> AddDocDetails(DocRequestDto doc)
    {
        var docDetails = new Document()
        {
            DocType = doc.DocType,
            DocImage = doc.DocImage
        };
        await _dbContext.Document.AddAsync(docDetails);
        await _dbContext.SaveChangesAsync(default(CancellationToken));

        // await _dbContext.Document.FindAsync(docDetails.DocID);
        var result = new DocResponseDto()
        {
            DocId = docDetails.DocID,
            DocType = docDetails.DocType,
            DocImage = docDetails.DocImage
        };
        return result;
    }


    public async Task<List<DocResponseDto>> GetAllDocsAsync()
    {
        var data = (from docData in _dbContext.Document
            select new DocResponseDto()
            {
                DocId = docData.DocID,
                DocType = docData.DocType,
                DocImage = docData.DocImage
            }).ToList();
        return data;
    }


    // Get Single Car
    public async Task<DocUserResDto?> GetSingleDoc(Guid id)
    {
        var doc = await _dbContext.Document.FindAsync(id);
        if (doc == null)
        {
            return new DocUserResDto()
            {
                Status = "Error",
                Message = "Document Not Found"
            };
        }

        var data = new DocUserResDto()
        {
            Status = "Success",
            Message = "Document Fetched Successfully",
            DocId = doc.DocID.ToString(),
            DocImage = doc.DocImage,
            DocType = doc.DocType
        };

        // var data = (from d in _dbContext.Document
        //     join docUser in _dbContext.AddUsers on d.DocID equals id
        //     select new DocUserResDto()
        //     {
        //         DocId = d.DocID.ToString(),
        //         DocImage = d.DocImage,
        //         DocType = d.DocType,
        //         UserId = docUser.Id,
        //         Name = docUser.Name,
        //         UserEmail = docUser.Email,
        //         UserRole = docUser.RoleUser
        //     }).FirstOrDefault();

        return data;
    }


    public Task<List<DocResponseDto>> GetAllDocs()
    {
        throw new NotImplementedException();
    }
}