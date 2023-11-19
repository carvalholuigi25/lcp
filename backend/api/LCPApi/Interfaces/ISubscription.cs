using LCPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LCPApi.Interfaces;

public interface ISubscription {
    Task<ActionResult<IEnumerable<Subscription>>> GetSubscription();
    Task<ActionResult<Subscription>> GetSubscriptionById(int id);
    Task<IActionResult> PutSubscription(int id, Subscription Subscription);
    Task<ActionResult<Subscription>> PostSubscription(Subscription Subscription);
    Task<IActionResult> DeleteSubscription(int id);
    Task<ActionResult<IEnumerable<SubscriptionKey>>> GetSubscriptionKey();
    Task<ActionResult<SubscriptionKey>> GetSubscriptionKeyById(int id);
    Task<IActionResult> PutSubscriptionKey(int id, SubscriptionKey subscriptionKey);
    Task<ActionResult<SubscriptionKey>> PostSubscriptionKey(SubscriptionKey subscriptionKey);
    Task<IActionResult> DeleteSubscriptionKey(int id);
}