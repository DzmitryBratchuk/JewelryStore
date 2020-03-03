using JewelryStoreAPI.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

using Entities = JewelryStoreAPI.Domain.Entities;

namespace JewelryStoreAPI.Tests.Services.Tests.Bijouterie
{

    public class BijouterieServiceTest : IClassFixture<BijouterieServiceFixture>
    {
        private readonly BijouterieServiceFixture _fixture;

        public BijouterieServiceTest(BijouterieServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAllAsync_NotEmptyResult()
        {
            var result = await _fixture.BijouterieService.GetAllAsync();

            _fixture.MockBijouterieRepository.Verify(x => x.GetAllAsync());

            Assert.Equal(_fixture.Entities.Count, result.Count);
        }

        [Fact]
        public async Task GetByIdAsync_BijouterieIdExist_NotEmptyResult()
        {
            var result = await _fixture.BijouterieService.GetByIdAsync(_fixture.BijouterieId);

            _fixture.MockBijouterieRepository.Verify(x => x.GetByIdAsync(_fixture.BijouterieId));

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_BijouterieIdDoesNotExist_ExceptionThrown()
        {
            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => _fixture.BijouterieService.GetByIdAsync(_fixture.IdDoesNotExist));

            _fixture.MockBijouterieRepository.Verify(x => x.GetByIdAsync(_fixture.IdDoesNotExist));
        }

        [Fact]
        public async Task GetAllByBijouterieTypeIdAsync_NotEmptyResult()
        {
            var result = await _fixture.BijouterieService.GetAllByBijouterieTypeIdAsync(_fixture.BijouterieTypeId);

            _fixture.MockBijouterieRepository.Verify(x => x.GetAllByBijouterieTypeIdAsync(_fixture.BijouterieTypeId));

            Assert.Equal(_fixture.Entities.Count, result.Count);
        }

        [Fact]
        public async Task GetAllByBrandIdAsync_NotEmptyResult()
        {
            var result = await _fixture.BijouterieService.GetAllByBrandIdAsync(_fixture.BrandId);

            _fixture.MockBijouterieRepository.Verify(x => x.GetAllByBrandIdAsync(_fixture.BrandId));

            Assert.Equal(_fixture.Entities.Count, result.Count);
        }

        [Fact]
        public async Task GetAllByCountryIdAsync_NotEmptyResult()
        {
            var result = await _fixture.BijouterieService.GetAllByCountryIdAsync(_fixture.CountryId);

            _fixture.MockBijouterieRepository.Verify(x => x.GetAllByCountryIdAsync(_fixture.CountryId));

            Assert.Equal(_fixture.Entities.Count, result.Count);
        }

        [Fact]
        public async Task CreateAsync_ValidBijouterieEntity_NotEmptyResult()
        {
            var result = await _fixture.BijouterieService.CreateAsync(_fixture.CreateBijouterieDto);

            _fixture.MockBijouterieRepository.Verify(x => x.CreateAsync(It.IsAny<Entities.Bijouterie>()));

            Assert.Equal(_fixture.BijouterieId, result.Id);
        }

        [Fact]
        public async Task CreateAsync_ValidBijouterieEntity_OrmExceptionThrown()
        {
            _fixture.SetupOrmDbUpdateException();

            await Assert.ThrowsAsync<DbUpdateException>(() => _fixture.BijouterieService.CreateAsync(_fixture.CreateBijouterieDto));

            _fixture.MockBijouterieRepository.Verify(x => x.SaveChangesAsync());

            _fixture.ResetOrmDbUpdateException();
        }

        [Fact]
        public async Task UpdateAsync_ValidBijouterieEntity_SuccessfulUpdate()
        {
            await _fixture.BijouterieService.UpdateAsync(_fixture.BijouterieId, _fixture.UpdateBijouterieDto);

            _fixture.MockBijouterieRepository.Verify(x => x.Update(It.IsAny<Entities.Bijouterie>()));
        }

        [Fact]
        public async Task UpdateAsync_BijouterieIdDoesNotExist_ExceptionThrown()
        {
            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => _fixture.BijouterieService.UpdateAsync(_fixture.IdDoesNotExist, _fixture.UpdateBijouterieDto));

            _fixture.MockBijouterieRepository.Verify(x => x.GetByIdAsync(_fixture.IdDoesNotExist));
        }

        [Fact]
        public async Task UpdateAsync_ValidBijouterieEntity_OrmExceptionThrown()
        {
            _fixture.SetupOrmDbUpdateException();

            await Assert.ThrowsAsync<DbUpdateException>(() => _fixture.BijouterieService.UpdateAsync(_fixture.BijouterieId, _fixture.UpdateBijouterieDto));

            _fixture.MockBijouterieRepository.Verify(x => x.SaveChangesAsync());

            _fixture.ResetOrmDbUpdateException();
        }

        [Fact]
        public async Task DeleteAsync_BijouterieIdExist_SuccessfulDeletion()
        {
            await _fixture.BijouterieService.DeleteAsync(_fixture.BijouterieId);

            _fixture.MockBijouterieRepository.Verify(x => x.Delete(It.IsAny<Entities.Bijouterie>()));
        }

        [Fact]
        public async Task DeleteAsync_BijouterieIdDoesNotExist_ExceptionThrown()
        {
            await Assert.ThrowsAsync<BaseBusinessJewelryStoreException>(() => _fixture.BijouterieService.DeleteAsync(_fixture.IdDoesNotExist));

            _fixture.MockBijouterieRepository.Verify(x => x.GetByIdAsync(_fixture.IdDoesNotExist));
        }

        [Fact]
        public async Task DeleteAsync_ValidBijouterieEntity_OrmExceptionThrown()
        {
            _fixture.SetupOrmDbUpdateException();

            await Assert.ThrowsAsync<DbUpdateException>(() => _fixture.BijouterieService.DeleteAsync(_fixture.BijouterieId));

            _fixture.MockBijouterieRepository.Verify(x => x.SaveChangesAsync());

            _fixture.ResetOrmDbUpdateException();
        }
    }
}
