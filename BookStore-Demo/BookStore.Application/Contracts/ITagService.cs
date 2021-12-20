namespace BookStore.Application.Contracts
{
    public interface ITagService : IServiceBase
    {
        Task<IList<ShowTagsDto>> GetAllAsync(CancellationToken cancellationToken);

        Task<DetailsTagDto> GetDetailsAsync(int id, CancellationToken cancellationToken);

        Task CreateAsync(CreateTagDto dto, CancellationToken cancellationToken);

        Task UpdateAsync(UpdateTagDto dto, CancellationToken cancellationToken);

        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
