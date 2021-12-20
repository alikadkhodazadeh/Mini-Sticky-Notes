namespace BookStore.Application.TagApp
{
    public class TagService : ITagService
    {
        private readonly IRepository<Tag> _repository;

        public TagService(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<IList<ShowTagsDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _repository.TableNoTracking.ProjectToType<ShowTagsDto>().ToListAsync(cancellationToken);
        }

        public async Task<DetailsTagDto> GetDetailsAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(cancellationToken, id);
            return result.Adapt<DetailsTagDto>();
        }

        public async Task CreateAsync(CreateTagDto dto, CancellationToken cancellationToken)
        {
            Tag tag = dto.Adapt<Tag>();
            await _repository.AddAsync(tag, cancellationToken);
        }

        public async Task UpdateAsync(UpdateTagDto dto, CancellationToken cancellationToken)
        {
            Tag tag = dto.Adapt<Tag>();
            await _repository.UpdateAsync(tag, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            Tag tag = await _repository.GetByIdAsync(cancellationToken, id);
            await _repository.DeleteAsync(tag, cancellationToken);
        }
    }
}
