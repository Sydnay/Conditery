﻿using Conditery.Constants;
using Conditery.Models;
using Conditery.Repository;
using VkBotFramework;
using VkBotFramework.Models;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Keyboard;
using VkNet.Model.RequestParams;

namespace Conditery
{
    internal class AppStart
    {
        const string token = "vk1.a.7KyPdYKqp5ANTIBuBFlNKW3wXvLJFE3AsVoc8zm-mmU8KcInZ6-EgrhXxbdp17HSt6Q52gllyfFp2JynQ6ZGBWWYhDyfsE9S2ir9APQNNtL_dglHec77iUB2fSFBd7cRmRhpxeoVnQvTbdIa225E8PSPb6YNytUNiybnK9aIyjN6Q-oHT_F3bopuEOE6_81t5x82gbgr3tlkmYbkoPHvlA";
        const string groupUri = "https://vk.com/club216986922";
        public static readonly VkBot bot = new VkBot(token, groupUri);
        private readonly IUserRepository userRepository;
        private readonly IOrderRepository orderRepository;
        public AppStart(IUserRepository userRepository, IOrderRepository orderRepository)
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
        }
        public async void Start()
        {
            bot.OnMessageReceived += HandleMessage;

            Console.WriteLine("SstartReceiveng");
            bot.Start();

            Console.ReadLine();
        }
        async void HandleMessage(object? sender, MessageReceivedEventArgs e)
        {
            var msg = e.Message.Text;
            var userId = e.Message.FromId ?? -1;
            var user = userRepository.GetUser(userId);
            var userCurrentEvent = user?.UserEventId ?? -1;

            if (user?.UserEventId is null && msg == "/start")
            {
                HandleStart1(sender, e);
                return;
            }
            if(userCurrentEvent == (int)EventType.HandleStart && msg == KeyboardText.createOrder1)
            {
                userRepository.SetCurrentEvent(userId, EventType.HandleCreateOrder);
                HandleCreateOrder2(sender, e);
                return;
            }
            if (msg == KeyboardText.cancelOrder)
            {
                userRepository.SetCurrentEvent(userId, EventType.HandleStart);
                HandleCancelOrder(sender, e);
                return;
            }
            if (userCurrentEvent == (int)EventType.HandleCreateOrder && (msg == KeyboardText.orderType2_1 || msg == KeyboardText.orderType2_2 || msg == KeyboardText.orderType2_3))
            {
                userRepository.SetCurrentEvent(userId, EventType.HandleOrderType);
                HandlerOrderType3(sender, e);
                return;
            }
            if (userCurrentEvent == (int)EventType.HandleOrderType)
            {
                userRepository.SetCurrentEvent(userId, EventType.HandleOrderDetails);
                HandlerOrderDetails4(sender, e);
                return;
            }
            if (userCurrentEvent == (int)EventType.HandleOrderDetails)
            {
                userRepository.SetCurrentEvent(userId, EventType.HandleOrderCity);
                HandleOrderCity5(sender, e);
                return;
            }
            if (userCurrentEvent == (int)EventType.HandleOrderCity && (msg == KeyboardText.PriceRange5_1 || msg == KeyboardText.PriceRange5_2 || msg == KeyboardText.PriceRange5_3 || msg == KeyboardText.PriceRange5_4))
            {
                userRepository.SetCurrentEvent(userId, EventType.HandleOrderPriceRange);
                HandleOrderPriceRange6(sender, e);
                return;
            }
            if (userCurrentEvent == (int)EventType.HandleOrderPriceRange)
            {
                userRepository.SetCurrentEvent(userId, EventType.HandleOrderDate);
                HandleOrderDate7(sender, e);
                return;
            }
            if (userCurrentEvent == (int)EventType.HandleOrderDate && msg == KeyboardText.orderAttachments7)
            {
                userRepository.SetCurrentEvent(userId, EventType.HandleOrderAttachments);
                HandleOrderAttachments8(sender, e);
                return;
            }
            if (userCurrentEvent == (int)EventType.HandleOrderAttachments || userCurrentEvent== (int)EventType.HandleOrderDate)
            {
                userRepository.SetCurrentEvent(userId, EventType.HandleStart);
                HandleOrderReady9(sender, e);
                return;
            }


            //switch (user?.UserEventId ?? -1, msg)
            //{
            //    case (-1, "/start"):
            //        if (user is null && msg == "/start")
            //        {
            //            HandleStart1(sender, e);
            //        }
            //        break;

            //    case ((int)EventType.HandleStart, KeyboardText.createOrder1):
            //        if (user is not null &&)
            //        {
            //            userRepository.SetCurrentEvent(userId, EventType.HandleCreateOrder);
            //            HandleCreateOrder2(sender, e);
            //        }
            //        break;
            //    case ((int)EventType.HandleCreateOrder, KeyboardText.orderType2_1 or KeyboardText.orderType2_2 or KeyboardText.orderType2_3):
            //        if (user is not null)
            //        {
            //            userRepository.SetCurrentEvent(userId, EventType.HandleOrderType);
            //            HandlerOrderType3(sender, e);
            //        }
            //        break;
            //    case ((int)EventType.HandleOrderType):
            //        if (user is not null)
            //        {
            //            userRepository.SetCurrentEvent(userId, EventType.HandleOrderDetails);
            //            HandlerOrderDetails4(sender, e);
            //        }
            //        break;
            //    case (int)EventType.HandleOrderDetails:
            //        if (user is not null)
            //        {
            //            userRepository.SetCurrentEvent(userId, EventType.HandleOrderCity);
            //            HandleOrderCity5(sender, e);
            //        }
            //        break;
            //    case (int)EventType.HandleOrderCity:
            //        if (user is not null)
            //        {
            //            userRepository.SetCurrentEvent(userId, EventType.HandleOrderPriceRange);
            //            HandleOrderPriceRange6(sender, e);
            //        }
            //        break;
            //    case (int)EventType.HandleOrderPriceRange:
            //        if (user is not null)
            //        {
            //            userRepository.SetCurrentEvent(userId, EventType.HandleOrderDate);
            //            HandleOrderDate7(sender, e);
            //        }
            //        break;
            //    case (int)EventType.HandleOrderDate:
            //        if (user is not null)
            //        {
            //            userRepository.SetCurrentEvent(userId, EventType.HandleOrderAttachments);
            //            HandleOrderAttachments8(sender, e);
            //        }
            //        break;
            //    case (int)EventType.HandleOrderAttachments or (int)EventType.HandleOrderDate:
            //        if (user is not null)
            //        {
            //            userRepository.SetCurrentEvent(userId, EventType.HandleStart);
            //            HandleOrderReady9(sender, e);
            //        }
            //        break;
            //    case > 0:
            //        if(user is not null && msg == KeyboardText.cancelOrder)
            //        {
            //            userRepository.SetCurrentEvent(userId, EventType.HandleStart);
            //            HandleCancelOrder(sender, e);
            //        }
            //        break;
            //    default:
            //        Console.WriteLine($"default {nameof(HandleMessage)}");
            //        break;
            //}
        }

        private void HandleCancelOrder(object? sender, MessageReceivedEventArgs e)
        {
            orderRepository.DeleteIncompleteOrder(e.Message.FromId ?? -1);

            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.createOrder1, "", KeyboardButtonColor.Default);

            AppStart.bot.Api.Messages.Send(new MessagesSendParams
            {
                Message = Message.start1,
                PeerId = e.Message.PeerId,
                RandomId = Math.Abs(Environment.TickCount),
                Keyboard = keyboard.Build(),
            });

            Console.WriteLine($"HandleCancelOrder");
        }

        async void HandleStart1(object? sender, MessageReceivedEventArgs e)
        {
            userRepository.AddUser(new User
            {
                UserId = e.Message.FromId ?? -1,
                UserEventId = (int)EventType.HandleStart,
            });

            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.createOrder1, "", KeyboardButtonColor.Default);

            AppStart.bot.Api.Messages.Send(new MessagesSendParams
            {
                Message = Message.start1,
                PeerId = e.Message.PeerId,
                RandomId = Math.Abs(Environment.TickCount),
                Keyboard = keyboard.Build(),
            });

            Console.WriteLine($"HandleStart");
        }

        async void HandleCreateOrder2(object? sender, MessageReceivedEventArgs e)
        {
            orderRepository.AddOrder(new Order
            {
                UserId = e.Message.FromId ?? -1,
                Type = e.Message.Text
            });

            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.orderType2_1, "", KeyboardButtonColor.Default)
            .AddButton(KeyboardText.orderType2_2, "", KeyboardButtonColor.Default)
            .AddButton(KeyboardText.orderType2_3, "", KeyboardButtonColor.Default)
            .AddLine().AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            AppStart.bot.Api.Messages.Send(new MessagesSendParams
            {
                Message = Message.createOrder2,
                PeerId = e.Message.PeerId,
                RandomId = Math.Abs(Environment.TickCount),
                Keyboard = keyboard.Build(),
            });

            Console.WriteLine($"HandleGender");
        }

        async void HandlerOrderType3(object? sender, MessageReceivedEventArgs e)
        {
            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            var order = orderRepository.GetIncompleteOrder(e.Message.FromId ?? 0);
            order.Type = e.Message.Text;
            orderRepository.SaveChangeAsync();

            AppStart.bot.Api.Messages.Send(new MessagesSendParams
            {
                Message = Message.orderDetails3,
                PeerId = e.Message.PeerId,
                RandomId = Math.Abs(Environment.TickCount),
                Keyboard=keyboard.Build(),
            });

            Console.WriteLine($"HandleCreation");
        }
        async void HandlerOrderDetails4(object? sender, MessageReceivedEventArgs e)
        {
            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            var order = orderRepository.GetIncompleteOrder(e.Message.FromId ?? 0);
            order.Description = e.Message.Text;
            orderRepository.SaveChangeAsync();

            AppStart.bot.Api.Messages.Send(new MessagesSendParams
            {
                Message = Message.orderCity4,
                PeerId = e.Message.PeerId,
                RandomId = Math.Abs(Environment.TickCount),
                Keyboard = keyboard.Build(),
            });

            Console.WriteLine($"HandleCreation");
        }

        async void HandleOrderCity5(object? sender, MessageReceivedEventArgs e)
        {
            var order = orderRepository.GetIncompleteOrder(e.Message.FromId ?? 0);
            order.Location = e.Message.Text;
            orderRepository.SaveChangeAsync();

            var keyboard = new KeyboardBuilder();
            keyboard
                .AddButton(KeyboardText.PriceRange5_1, "", KeyboardButtonColor.Positive).AddLine()
                .AddButton(KeyboardText.PriceRange5_2, "", KeyboardButtonColor.Default)
                .AddButton(KeyboardText.PriceRange5_3, "", KeyboardButtonColor.Default).AddLine()
                .AddButton(KeyboardText.PriceRange5_4, "", KeyboardButtonColor.Negative)
                .AddLine().AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            AppStart.bot.Api.Messages.Send(new MessagesSendParams
            {
                Message = Message.orderPriceRange5,
                PeerId = e.Message.PeerId,
                RandomId = Math.Abs(Environment.TickCount),
                Keyboard = keyboard.Build()
            });

            Console.WriteLine($"HandleCreation");
        }
        async void HandleOrderPriceRange6(object? sender, MessageReceivedEventArgs e)
        {
            var order = orderRepository.GetIncompleteOrder(e.Message.FromId ?? 0);
            order.Price = e.Message.Text;
            orderRepository.SaveChangeAsync();

            var keyboard = new KeyboardBuilder();
            var lastDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1 == 12 ? 12 : DateTime.Now.Month + 1, 1).AddDays(-1).Day;//ето валидирует декабрб

            for (int i = DateTime.Now.Day + 1, j = 1; i <= lastDay; i++, j++)
            {
                keyboard.AddButton(new DateOnly(DateTime.Now.Year, DateTime.Now.Month, i).ToString(), "", KeyboardButtonColor.Default);

                if (j % 3 == 0)
                    keyboard.AddLine();
            }
            keyboard.AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);
            AppStart.bot.Api.Messages.Send(new MessagesSendParams
            {
                Message = Message.orderExecutionDate6,
                PeerId = e.Message.PeerId,
                RandomId = Math.Abs(Environment.TickCount),
                Keyboard = keyboard.Build()
            });

            Console.WriteLine($"HandleCreation");
        }
        async void HandleOrderDate7(object? sender, MessageReceivedEventArgs e)
        {
            var order = orderRepository.GetIncompleteOrder(e.Message.FromId ?? 0);
            order.ExecutionDate = DateTime.Parse(e.Message.Text);
            orderRepository.SaveChangeAsync();

            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.orderAttachments7, "", KeyboardButtonColor.Default)
                .AddButton(KeyboardText.orderReady7, "", KeyboardButtonColor.Positive)
                .AddLine().AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            AppStart.bot.Api.Messages.Send(new MessagesSendParams
            {
                Message = Message.orderConfirmation7,
                PeerId = e.Message.PeerId,
                RandomId = Math.Abs(Environment.TickCount),
                Keyboard = keyboard.Build()
            });

            Console.WriteLine($"HandleCreation");
        }
        async void HandleOrderAttachments8(object? sender, MessageReceivedEventArgs e)
        {
            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.cancelOrder, "", KeyboardButtonColor.Negative);

            AppStart.bot.Api.Messages.Send(new MessagesSendParams
            {
                Message = Message.orderAttachments8,
                PeerId = e.Message.PeerId,
                RandomId = Math.Abs(Environment.TickCount),
                Keyboard = keyboard.Build()
            });

            Console.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
        }

        async void HandleOrderReady9(object? sender, MessageReceivedEventArgs e)
        {
            var order = orderRepository.GetIncompleteOrder(e.Message.FromId ?? 0);
            order.UpdateTime = DateTime.Now;
            orderRepository.SaveChangeAsync();

            var attach = e.Message.Attachments;
            var keyboard = new KeyboardBuilder();
            keyboard.AddButton(KeyboardText.createOrder1, "", KeyboardButtonColor.Default);

            AppStart.bot.Api.Messages.Send(new MessagesSendParams
            {
                Attachments = attach.Select(x => x.Instance),
                Message = Message.orderReady,
                PeerId = e.Message.PeerId,
                RandomId = Math.Abs(Environment.TickCount),
                Keyboard = keyboard.Build()
            });

            Console.WriteLine($"HandleCreation");
        }

    }
}
