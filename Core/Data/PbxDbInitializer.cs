using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace DB_CourseWork.Core.Data
{
    public class PbxDbInitializer : CreateDatabaseIfNotExists<PbxContext>
    {
        protected override void Seed(PbxContext context)
        {
            var phoneTypes = new List<PhoneType>()
            {
                new PhoneType("Основной"),
                new PhoneType("Спаренный"),
                new PhoneType("Параллельный")
            };
            context.PhoneTypes.AddRange(phoneTypes);

            var payphones = new List<Payphone>()
            {
                new Payphone("123-45-67", "ул. Кирова"),
                new Payphone("123-45-69", "ул. Лермонтова") { IsEnabled = true }
            };
            context.Payphones.AddRange(payphones);

            var subPhones = new List<SubscriberPhone>()
            {
                new SubscriberPhone("123-45-10", phoneTypes[0], "ул. Красная, д. 10", "Иванов Иван Иванович"),
                new SubscriberPhone("123-45-11", phoneTypes[1], "ул. Красная, д. 11", "Петров Петр Петрович")  { AccountBalance = 100 },
                new SubscriberPhone("123-45-12", phoneTypes[2], "ул. Красная, д. 12", "Жмышенко Валерий Альбертович") { IsReducedRate = true }
            };
            context.SubscriberPhones.AddRange(subPhones);

            var statuses = new List<PhoneStatus>()
            {
                new PhoneStatus("Подключен"),
                new PhoneStatus("Отключен"),
                new PhoneStatus("Отключен за неуплату")
            };
            context.PhoneStatuses.AddRange(statuses);

            var statusHistoryEntries = new List<StatusHistoryEntry>()
            {
                new StatusHistoryEntry(subPhones[0], statuses[0], DateTime.Now, ""),
                new StatusHistoryEntry(subPhones[0], statuses[1], DateTime.Now, ""),
                new StatusHistoryEntry(subPhones[1], statuses[0], DateTime.Now, ""),
                new StatusHistoryEntry(subPhones[2], statuses[2], DateTime.Now, "Недобросовестный абонент!!1")
            };
            context.StatuseHistoryEntries.AddRange(statusHistoryEntries);

            var tariffs = new List<Tariff>()
            {
                new Tariff("Тариф 'Обычный'", 199),
                new Tariff("Тариф 'Продвинутый'", 249),
            };
            context.Tariffs.AddRange(tariffs);

            var tariffHistoryEntries = new List<TariffHistoryEntry>()
            {
                new TariffHistoryEntry(subPhones[0], tariffs[0], DateTime.Now),
                new TariffHistoryEntry(subPhones[0], tariffs[1], DateTime.Now),
                new TariffHistoryEntry(subPhones[1], tariffs[0], DateTime.Now),
                new TariffHistoryEntry(subPhones[2], tariffs[1], DateTime.Now),
            };
            context.TariffHistoryEntries.AddRange(tariffHistoryEntries);

            var payments = new List<Payment>()
            {
                new Payment(subPhones[0], 100, DateTime.Now),
                new Payment(subPhones[0], 150, DateTime.Now),
                new Payment(subPhones[0], 200, DateTime.Now),
                new Payment(subPhones[1], 119, DateTime.Now),
                new Payment(subPhones[1], 69, DateTime.Now),
                new Payment(subPhones[1], 420, DateTime.Now),
            };
            context.Payments.AddRange(payments);

            var payphoneCards = new List<PayphoneCard>()
            {
                new PayphoneCard("123456", 100, DateTime.Now),
                new PayphoneCard("123457", 95, DateTime.Now),
            };
            context.PayphoneCards.AddRange(payphoneCards);

            var calls = new List<Call>()
            {
                new Call(payphones[0], "8(800)5553535", DateTime.Now, 5, true)
            };
            calls.First().PayphoneCards.Add(payphoneCards[1]);
            context.Calls.AddRange(calls);

            base.Seed(context);
        }
    }
}
