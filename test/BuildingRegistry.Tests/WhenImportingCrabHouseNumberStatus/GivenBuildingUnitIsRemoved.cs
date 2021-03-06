namespace BuildingRegistry.Tests.WhenImportingCrabHouseNumberStatus
{
    using System;
    using Be.Vlaanderen.Basisregisters.AggregateSource.Testing;
    using Autofixture;
    using AutoFixture;
    using Building;
    using Building.Commands.Crab;
    using Building.Events;
    using ValueObjects;
    using Xunit;
    using Xunit.Abstractions;

    public class GivenBuildingUnitIsRemoved : AutofacBasedTest
    {
        private readonly Fixture _fixture = new Fixture();

        public GivenBuildingUnitIsRemoved(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            _fixture.Customize(new InfrastructureCustomization());
            _fixture.Customize(new WithNoDeleteModification());
            _fixture.Customize(new WithFixedBuildingUnitIdFromHouseNumber());
        }

        [Fact]
        public void ThenOnlyLegacyEventIsApplied()
        {
            _fixture.Customize(new WithNoDeleteModification());

            var command = _fixture.Create<ImportHouseNumberStatusFromCrab>();
            var buildingId = _fixture.Create<BuildingId>();

            Assert(new Scenario()
                .Given(buildingId,
                    _fixture.Create<BuildingWasRegistered>(),
                    _fixture.Create<BuildingUnitWasAdded>(),
                    _fixture.Create<BuildingUnitWasRemoved>())
                .When(command)
                .Then(buildingId, command.ToLegacyEvent()));
        }
    }
}
