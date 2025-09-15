using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR.Domain;
using IT_Portal.Application.Features.SR.Email;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IserviceMaster
    {
        Task<CommonRsult> postService(serviceRequestSoft request);
        Task<CommonRsult> getService(ESRfilterRequest request);
        Task<CommonRsult> getServiceSoft(ESRfilterRequest request);
        Task<CommonRsult> getDomain(ESRfilterRequest request);
        Task<CommonRsult> submitResolution(ESrSoftwareResolution request);
        Task<CommonRsult> getApprover(string suppId);
        Task<CommonRsult> getSRApproved(int id);
        Task<CommonRsult> getResolution(ESRfilterRequest filterRquest);
        Task<CommonRsult> getHistory(ESRfilterRequest filterRquest);
        Task<CommonRsult> getResolutionHistory(ESRfilterRequest filterRquest);
        Task<CommonRsult> saveDomain(EdomainRequest request);
        Task<CommonRsult> saveEmailService(EemailRequest request);
        Task<CommonRsult> assignTo(ESRAssignTo request);
        Task<CommonRsult> DeleteSRById(int id);

    }
}
