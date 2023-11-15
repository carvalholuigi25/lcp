using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface ISubscriptions {
    Task<ActionResult<IEnumerable<Subscriptions>>> GetSubscriptions();
    Task<ActionResult<Subscriptions>> GetSubscriptionsById(int id);
    Task<IActionResult> PutSubscriptions(int id, Subscriptions Subscriptions);
    Task<ActionResult<Subscriptions>> PostSubscriptions(Subscriptions Subscriptions);
    Task<IActionResult> DeleteSubscriptions(int id);
}