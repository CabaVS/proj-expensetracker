using CabaVS.ExpenseTracker.Application.Abstractions.Persistence;
using CabaVS.ExpenseTracker.Application.Abstractions.UserContext;
using CabaVS.ExpenseTracker.Domain.Common;
using CabaVS.ExpenseTracker.Domain.Entities;
using MediatR;

namespace CabaVS.ExpenseTracker.Application.UseCases.Workspaces.Commands;

public sealed record CreateWorkspaceCommand(string Name)
    : IRequest<Result<Guid>>;

internal sealed class CreateWorkspaceCommandHandler(ICurrentUserAccessor currentUserAccessor, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateWorkspaceCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
    {
        Result<Workspace> result = Workspace.CreateNew(request.Name);
        return await result.Map<Workspace, Guid>(async workspace =>
        {
            await unitOfWork.Workspaces.AddAsync(
                workspace, 
                cancellationToken);
            await unitOfWork.WorkspaceMembers.AddUserToTheWorkspaceAsync(
                workspace,
                currentUserAccessor.GetCurrentUserId(),
                true,
                cancellationToken);
            
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            return workspace.Id;
        });
    }
}
