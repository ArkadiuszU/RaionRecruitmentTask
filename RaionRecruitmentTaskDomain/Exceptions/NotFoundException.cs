

namespace RaionRecruitmentTaskDomain.Exceptions
{
    public class NotFoundException(string resourceType, int? resourceId) 
        : Exception($"{resourceType} with id: {resourceId} does not exist")
    {


    }
}
