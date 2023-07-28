using Architecture.Domain.EventBus;
using Architecture.Domain.EventBus.Outbox;

namespace Architecture.Tests.Domain.EventBus.Outbox;

public class IntegrationEventEntryTests
{
    [Fact]
    public void 應該成功發起IntegrationEventEntry()
    {
        // Given
        var integrationEvent = GetIntegrationEvent();
        var transactionId = Guid.NewGuid();

        // When
        var integrationEventEntry = IntegrationEventEntry.Raise(integrationEvent, transactionId);

        // Then
        integrationEventEntry.Id.Should().Be(integrationEvent.Id);
        integrationEventEntry.CreationTimestamp.Should().Be(integrationEvent.CreationTimestamp);
        integrationEventEntry.TypeName.Should().Be(integrationEvent.TypeName);
        integrationEventEntry.Message.Should().Be(integrationEvent.Message);
        integrationEventEntry.State.Should().Be(State.Raised);
        integrationEventEntry.TransactionId.Should().Be(transactionId);
    }

    [Fact]
    public void 安排動作後_狀態應該是InProgress()
    {
        // Given
        var integrationEvent = GetIntegrationEventEntry();

        // When
        integrationEvent.Progress();

        // Then
        integrationEvent.State.Should().Be(State.InProgress);
    }

    [Fact]
    public void 發佈後_狀態應該要是Published()
    {
        // Given
        var integrationEvent = GetIntegrationEventEntry();
        integrationEvent.Progress();

        // When
        integrationEvent.Publish();

        // Then
        integrationEvent.State.Should().Be(State.Published);
    }

    private static IntegrationEvent GetIntegrationEvent()
    {
        var somethingIntegrationEvent = new SomethingIntegrationEvent();
        var integrationEvent = IntegrationEvent.Create(somethingIntegrationEvent);
        return integrationEvent;
    }

    private static IntegrationEventEntry GetIntegrationEventEntry()
    {
        var integrationEvent = GetIntegrationEvent();
        var transactionId = Guid.NewGuid();
        var integrationEventEntry = IntegrationEventEntry.Raise(integrationEvent, transactionId);
        return integrationEventEntry;
    }
}
