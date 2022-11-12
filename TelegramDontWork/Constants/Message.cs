using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Constants
{
    static internal class Message
    {
        public const string start1 = "Здравствуйте! Данный бот поможет вам найти кондитера, который сможет осуществить ваши сладкие мечты.Для начала, нажмите на кнопку создать заказ ";
        public const string createOrder2 = "Сейчас мы составим ваш заказ. Для начала давайте выберем вид кондитерского изделия";
        public const string orderDetails3 = "Вид вашего кондитерского изделия подтвержден.\nДавайте добавим описание к вашему заказу";
        public const string orderCity4 = "Описание подтверждено.\nНапишите город, в котором нужно будет выполнить заказ";
        public const string orderPriceRange5 = "Город подтвержден.Выберете приемлемый диапазон цены";
        public const string orderExecutionDate6 = "Диапазон цен утвержден.\nТеперь определимся с датой выполнения заказа.";
        public const string orderExecutionDateFailed6 = "Неверный формат даттттттттты";
        public const string orderConfirmation7 = "Дата выполнения заказа утверждена.Если у вас есть фото примера изделия, которого вы хотите, то нажмите кнопку \"Вложения\". Это поможет с уточнением деталей по вашему заказу.В ином случае, нажмите кнопку \"Завершить создание заказа\"";
        public const string orderAttachments8 = "Вставьте фото  примера изделия, которого вы хотите.";
        public const string orderReady = "Заказ успешно создан и отправлен на модерацию. В течении часа он будет выставлен в общем чате кондитеров.\nДанный заказ будет действителен три дня.После истечения этого срока, вам придет сообщение с просьбой подтвердить актуальность данного заказа.";
    }

    static internal class KeyboardText
    {
        public const string createOrder1 = "Создать заказ";
        public const string orderType2_1 = "Пирожные";
        public const string orderType2_2 = "Торты";
        public const string orderType2_3 = "Еще хуйня какая-нибудь";
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
