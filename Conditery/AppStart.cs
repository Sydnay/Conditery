using Conditery.Constants;
using Conditery.Models;
using Conditery.Services;
using Serilog;
using System.Configuration;
using VkBotFramework;
using VkBotFramework.Models;
using VkNet;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.Keyboard;
using VkNet.Model.RequestParams;

namespace Conditery
{
    public class AppStart
    {
        static AppSettingsSection config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings;
        public static readonly VkApi api = new VkApi();
        public static readonly VkBot bot = new VkBot("vk1.a.BEed2F1ppev8SvdVzRbzJcQx6t-zx98FpVV7Q4mCqQZ8_-JzBXbMBYwgCQKRrwHcP2G-AlF8clg3Jgm20t9ubelFv5xC1m2XrfWD48fdbJcM35Fta74wYxJPMf4jrahumVprWG16l9yvuT70H_QCzMUtZudD4qDS6tBvv9VfCeQml3adZ2ahgrjUdhAu85GPeSJkSX4U9G3mWzq45Uz3IQ", config.Settings["groupUri"].Value);

        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        public AppStart(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }
        public async void Start()
        {
            try
            {
                api.Authorize(new ApiAuthParams
                {
                    AccessToken = "vk1.a.BEed2F1ppev8SvdVzRbzJcQx6t-zx98FpVV7Q4mCqQZ8_-JzBXbMBYwgCQKRrwHcP2G-AlF8clg3Jgm20t9ubelFv5xC1m2XrfWD48fdbJcM35Fta74wYxJPMf4jrahumVprWG16l9yvuT70H_QCzMUtZudD4qDS6tBvv9VfCeQml3adZ2ahgrjUdhAu85GPeSJkSX4U9G3mWzq45Uz3IQ"
                });

                Console.WriteLine(api.Token);
                Log.Information("Бот начал работу");

                bot.OnGroupUpdateReceived += async (s, e) => await HandleStart(s, e);
                bot.OnMessageReceived += async (s, e) => await HandleMessage(s, e);

                Console.WriteLine("SstartReceiveng");
                bot.Start();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message);
                throw ex;
            }
        }
        async Task HandleMessage(object? sender, MessageReceivedEventArgs e)
        {
            var msg = e.Message.Text;
            var userId = e.Message.FromId ?? -1;

            try
            {
                var user = await _userService.GetUser(userId);
                var userCurrentEvent = user?.UserEventId ?? -1;

                if (user is null)
                    return;

                if (userCurrentEvent == (int)EventType.HandleStart && msg == KeyboardText.createOrder1)
                {
                    await _userService.SetCurrentEvent(userId, EventType.HandleCreateOrder);
                    await HandleCreateOrder2(sender, e);
                    Console.WriteLine($"[{DateTime.UtcNow}] Пользователь {userId} начал создание заказа");
                    return;
                }
                if (msg == KeyboardText.cancelOrder)
                {
                    await _userService.SetCurrentEvent(userId, EventType.HandleStart);
                    await HandleCancelOrder(sender, e);
                    Console.WriteLine($"[{DateTime.UtcNow}] Пользователь {userId} Отменил заказ");
                    return;
                }
                if (userCurrentEvent == (int)EventType.HandleCreateOrder && (msg == KeyboardText.orderType2_1 || msg == KeyboardText.orderType2_2 || msg == KeyboardText.orderType2_3 || msg == KeyboardText.orderType2_4 || msg == KeyboardText.orderType2_5 || msg == KeyboardText.orderType2_6 || msg == KeyboardText.orderType2_7 || msg == KeyboardText.orderType2_8 || msg == KeyboardText.orderType2_9))
                {
                    await _userService.SetCurrentEvent(userId, EventType.HandleOrderType);
                    await HandlerOrderType3(sender, e);
                    Console.WriteLine($"[{DateTime.UtcNow}] Пользователь {userId} выбрал тип заказа");
                    return;
                }
                if (userCurrentEvent == (int)EventType.HandleOrderType)
                {
                    await _userService.SetCurrentEvent(userId, EventType.HandleOrderDetails);
                    await HandlerOrderDetails4(sender, e);
                    Console.WriteLine($"[{DateTime.UtcNow}] Пользователь {userId} добавил описание заказа");
                    return;
                }
                if (userCurrentEvent == (int)EventType.HandleOrderDetails)
                {
                    await _userService.SetCurrentEvent(userId, EventType.HandleOrderCity);
                    await HandleOrderCity5(sender, e);
                    Console.WriteLine($"[{DateTime.UtcNow}] Пользователь {userId} добавил город к заказу");
                    return;
                }
                if (userCurrentEvent == (int)EventType.HandleOrderCity && (msg == KeyboardText.PriceRange5_1 || msg == KeyboardText.PriceRange5_2 || msg == KeyboardText.PriceRange5_3 || msg == KeyboardText.PriceRange5_4))
                {
                    await _userService.SetCurrentEvent(userId, EventType.HandleOrderPriceRange);
                    await HandleOrderPriceRange6(sender, e);
                    Console.WriteLine($"[{DateTime.UtcNow}] Пользователь {userId} определил ценовой диапазон");
                    return;
                }
                if (userCurrentEvent == (int)EventType.HandleOrderPriceRange)
                {
                    await _userService.SetCurrentEvent(userId, EventType.HandleOrderDate);
                    await HandleOrderDate7(sender, e);
                    Console.WriteLine($"[{DateTime.UtcNow}] Пользователь {userId} выбрал дату заказа");
                    return;
                }
                if (userCurrentEvent == (int)EventType.HandleOrderDate && msg == KeyboardText.orderAttachments7)
                {
                    await _userService.SetCurrentEvent(userId, EventType.HandleOrderAttachments);
                    await HandleOrderAttachments8(sender, e);
                    Console.WriteLine($"[{DateTime.UtcNow}] Пользователь {userId} добавил вложения к заказу");
                    return;
                }
                if (userCurrentEvent == (int)EventType.HandleOrderAttachments || (userCurrentEvent == (int)EventType.HandleOrderDate && msg == KeyboardText.orderReady7))
                {
                    await _userService.SetCurrentEvent(userId, EventType.HandleStart);
                    await HandleOrderReady9(sender, e);
                    Console.WriteLine($"[{DateTime.UtcNow}] Пользователь {userId} завершил создание заказа ");
                    return;
                }
            }
            catch (Exception ex)
            {
                var keyboard = new KeyboardBuilder();
                keyboard.AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

                Log.Error($"User {userId} " + ex.Message);
                await SendMessageAsync("Что-то пошло не так, нажмите кнопку \"Отменить Заказ\"", e.Message.FromId ?? -1, keyboard);
            }
        }

        private async Task HandleStart(object? sender, GroupUpdateReceivedEventArgs e)
        {
            if (e.Update.Type.ToString() == "group_join")
            {
                try
                {
                    var user = await _userService.GetUser(e.Update.GroupJoin.UserId ?? -1);

                    if (user is not null)
                        return;

                    await _userService.AddUser(new Models.User
                    {
                        UserId = e.Update.GroupJoin.UserId ?? -1,
                        UserEventId = (int)EventType.HandleStart,
                    });

                    var keyboard = new KeyboardBuilder();
                    keyboard.AddButton(KeyboardText.createOrder1, "", KeyboardButtonColor.Default);
                    await SendMessageAsync(Constants.Message.start1, e.Update.GroupJoin.UserId, keyboard);

                    Console.WriteLine($"[{DateTime.UtcNow}] Пользователь {e.Update.GroupJoin.UserId ?? -1} Подписался на группу");
                }
                catch (Exception ex)
                {
                    Log.Error($"User {e.Update.GroupJoin.UserId ?? -1} " + ex.Message);

                    var keyboard = new KeyboardBuilder();
                    keyboard.AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

                    await SendMessageAsync("Что-то пошло не так, нажмите кнопку \"Отменить Заказ\"", e.Update.GroupJoin.UserId, keyboard);
                }
            }
        }

        async Task HandleCancelOrder(object? sender, MessageReceivedEventArgs e)
        {
            await _orderService.DeleteIncompleteOrder(e.Message.FromId ?? -1);

            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.createOrder1, "", KeyboardButtonColor.Default);

            await SendMessageAsync(Constants.Message.start1, e.Message.FromId, keyboard);
        }

        async Task HandleCreateOrder2(object? sender, MessageReceivedEventArgs e)
        {
            await _orderService.AddOrder(new Models.Order
            {
                UserId = e.Message.FromId ?? -1,
                Type = e.Message.Text
            });

            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.orderType2_1, "", KeyboardButtonColor.Default)
            .AddButton(KeyboardText.orderType2_4, "", KeyboardButtonColor.Default)
            .AddButton(KeyboardText.orderType2_7, "", KeyboardButtonColor.Default).AddLine()
            .AddButton(KeyboardText.orderType2_2, "", KeyboardButtonColor.Default)
            .AddButton(KeyboardText.orderType2_5, "", KeyboardButtonColor.Default)
            .AddButton(KeyboardText.orderType2_8, "", KeyboardButtonColor.Default).AddLine()
            .AddButton(KeyboardText.orderType2_3, "", KeyboardButtonColor.Default)
            .AddButton(KeyboardText.orderType2_6, "", KeyboardButtonColor.Default)
            .AddButton(KeyboardText.orderType2_9, "", KeyboardButtonColor.Default)
            .AddLine().AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            await SendMessageAsync(Constants.Message.createOrder2, e.Message.FromId, keyboard);
        }

        async Task HandlerOrderType3(object? sender, MessageReceivedEventArgs e)
        {
            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            var order = await _orderService.GetIncompleteOrder(e.Message.FromId ?? 0);
            order.Type = e.Message.Text;
            await _orderService.UpdateOrder(order);

            await SendMessageAsync(Constants.Message.orderDetails3, e.Message.FromId, keyboard);
        }
        async Task HandlerOrderDetails4(object? sender, MessageReceivedEventArgs e)
        {
            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            var order = await _orderService.GetIncompleteOrder(e.Message.FromId ?? 0);
            order.Description = e.Message.Text;
            await _orderService.UpdateOrder(order);

            await SendMessageAsync(Constants.Message.orderCity4, e.Message.FromId, keyboard);
        }

        async Task HandleOrderCity5(object? sender, MessageReceivedEventArgs e)
        {
            var order = await _orderService.GetIncompleteOrder(e.Message.FromId ?? 0);
            order.Location = e.Message.Text;
            await _orderService.UpdateOrder(order);

            var keyboard = new KeyboardBuilder();
            keyboard
                .AddButton(KeyboardText.PriceRange5_1, "", KeyboardButtonColor.Positive).AddLine()
                .AddButton(KeyboardText.PriceRange5_2, "", KeyboardButtonColor.Default)
                .AddButton(KeyboardText.PriceRange5_3, "", KeyboardButtonColor.Default).AddLine()
                .AddButton(KeyboardText.PriceRange5_4, "", KeyboardButtonColor.Negative)
                .AddLine().AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            await SendMessageAsync(Constants.Message.orderPriceRange5, e.Message.FromId, keyboard);
        }
        async Task HandleOrderPriceRange6(object? sender, MessageReceivedEventArgs e)
        {
            var order = await _orderService.GetIncompleteOrder(e.Message.FromId ?? 0);
            order.Price = e.Message.Text;
            await _orderService.UpdateOrder(order);

            var keyboard = new KeyboardBuilder();
            var lastDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1 == 13 ? 12 : DateTime.Now.Month + 1, 1).AddDays(-1).Day;//ето валидирует декабрб
            var month = DateTime.Now.Month;
            for (int i = DateTime.Now.Day + 1, j = 1; j <= 20; i++, j++)
            {
                keyboard.AddButton(new DateOnly(DateTime.Now.Year, month, i).ToString(), "", KeyboardButtonColor.Default);

                if (i == lastDay)
                {
                    month = month + 1 == 13 ? 1 : month + 1;
                    i = 0;
                }

                if (j % 3 == 0)
                    keyboard.AddLine();
            }
            keyboard.AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            await SendMessageAsync(Constants.Message.orderExecutionDate6, e.Message.FromId, keyboard);
        }
        async Task HandleOrderDate7(object? sender, MessageReceivedEventArgs e)
        {
            var order = await _orderService.GetIncompleteOrder(e.Message.FromId ?? 0);
            try
            {
                order.ExecutionDate = DateTime.Parse(e.Message.Text);
            }
            catch
            {
                await _userService.SetCurrentEvent(e.Message.FromId ?? -1, EventType.HandleOrderPriceRange);
                return;
            }
            await _orderService.UpdateOrder(order);

            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.orderAttachments7, "", KeyboardButtonColor.Default)
                .AddButton(KeyboardText.orderReady7, "", KeyboardButtonColor.Positive)
                .AddLine().AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            await SendMessageAsync(Constants.Message.orderConfirmation7, e.Message.FromId, keyboard);
        }
        async Task HandleOrderAttachments8(object? sender, MessageReceivedEventArgs e)
        {
            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            await SendMessageAsync(Constants.Message.orderAttachments8, e.Message.FromId, keyboard);
        }

        async Task HandleOrderReady9(object? sender, MessageReceivedEventArgs e)
        {
            var order = await _orderService.GetIncompleteOrder(e.Message.FromId ?? 0);
            order.UpdateTime = DateTime.Now;
            await _orderService.UpdateOrder(order);

            var attach = e.Message.Attachments;
            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.createOrder1, "", KeyboardButtonColor.Default);

            await SendMessageAsync(Constants.Message.orderReady + $"\n\nИнформация о заказе:\nТип: {order.Type}\nДетали: {order.Description}\nГород: {order.Location}\nЦеновой диапазон: {order.Price}\nДата исполнения: {order.ExecutionDate.ToShortDateString()}", e.Message.FromId, keyboard, attach.Select(x => x.Instance));

            var user = (await bot.Api.Users.GetAsync(new List<long> { e.Message.FromId ?? -1 })).FirstOrDefault();

            await SendMessageAsync($"Заказ от {user.FirstName} {user.LastName} https://vk.com/id{user.Id} \n\nТип: #{order.Type.Replace("-", "_").Replace(" ", "_")}\nДетали: {order.Description}\nГород: #{order.Location.Replace("-", "_").Replace(" ", "_")}\nЦеновой диапазон: #{order.Price.Replace(" ", "_")}\nДата исполнения: {order.ExecutionDate.ToShortDateString()}", 2000000001, attachments:attach.Select(x => x.Instance));
        }
        public static async Task SendMessageAsync(string msg, long? peerId, KeyboardBuilder keyboard = null, IEnumerable<MediaAttachment> attachments = null)
        {
            try
            {
                await api.Messages.SendAsync(new MessagesSendParams
                {
                    Attachments = attachments,
                    Message = msg,
                    PeerId = peerId,
                    RandomId = Math.Abs(Environment.TickCount),
                    Keyboard = keyboard?.Build()
                });
            }
            catch (Exception ex)
            {
                await SendMessageAsync($"Произошла ошибка при отправке сообщения пользователю https://vk.com/id{peerId}. Ошибка: {ex.Message}", 2000000001);
            }
        }
    }
}
