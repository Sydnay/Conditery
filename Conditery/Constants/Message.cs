using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Constants
{
    static internal class Message
    {
        public const string start1 = "Здравствуйте! Заполните короткую анкету и мы отправим ваш заказ нашим кондитерам! \n\nЧтобы начать, нажмите на кнопку \"Cоздать заказ\"";
        public const string createOrder2 = "Давйте составим заказ вместе! Выберите тип изделия \n\nЕсли ни один из вариантов вам не подошёл, нажмите \"Другое\" и добавьте свой тип в следующем пункте анкеты";
        public const string getListOrders2 = "Выебирте заказ";
        public const string orderDetails3 = "Теперь нужно добавить описание заказа.\n\nОпишите свои пожелания, например: начинку, крем, сочетание вкусов, цвет, дизайн.\n\nДизайн изделия можно будет прикрепить в последнем пункте анкеты, вы также можете приложить фотографию из нашей группы.";
        public const string orderCity4 = "Ещё несколько шагов!\n\nУкажите город, в котором вы заберёте свой заказ:";
        public const string orderPriceRange5 = "Наши кондитеры работают с тортами разной стоимости, чтобы каждый мог воспользоваться нашим сервисом.\n\nПожалуйста, укажите диапазон цены:";
        public const string orderExecutionDate6 = "Укажите дату, к которой вы хотели бы получить заказ:";
        public const string orderExecutionDateFailed6 = "Неверный формат датттты";
        public const string orderConfirmation7 = "В нашей группе вы можете найти множество готовых дизайнов кондитерских изделий!\n\nПрикрепите фотографию оттуда или добавьте свою.\n\n*Этот шаг является необязательным. Дизайн торта вы сможете обсудить с кондитером позже.";
        public const string orderAttachments8 = "Вставьте фото  примера изделия, которого вы хотите.";
        public const string orderReady = "Заказ успешно создан и отправлен на модерацию. В течение часа он будет доступен для просмотра нашим кондитерам!\n\nВаш заказ будет актуален 3 дня, если на него никто не откликнется, бот попросит вас подтвердить актуальность заказа.\n\nТак, ваш заказ будет выше в топе заказов, что поможет Вам быстрее найти кондитера.";
    }

    static internal class KeyboardText
    {
        public const string createOrder1 = "Создать заказ";
        public const string listOrders1 = "Мои заказы";
        public const string orderType2_1 = "Пирожные";
        public const string orderType2_2 = "Торты";
        public const string orderType2_3 = "Пироги";
        public const string orderType2_4 = "Капкейки";
        public const string orderType2_5 = "Пончики";
        public const string orderType2_6 = "Бенто-торты";
        public const string orderType2_7 = "Эклеры";
        public const string orderType2_8 = "Круассаны";
        public const string orderType2_9 = "Другое";
        public const string PriceRange5_1 = "До 1500 руб.";
        public const string PriceRange5_2 = "От 1500 до 2500 руб.";
        public const string PriceRange5_3 = "От 2500 до 5000 руб.";
        public const string PriceRange5_4 = "Свыше 5000 руб.";
        public const string orderAttachments7 = "Вложения";
        public const string orderReady7 = "Завершить создание заказа";

        public const string goBack = "Назад";
        public const string cancelOrder = "Отменить заказ";
    }
}
