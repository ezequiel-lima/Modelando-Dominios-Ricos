﻿using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType documentType)
        {
            Number = number;
            DocumentType = documentType;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento invalido")
            );
        }

        public string Number { get; private set; }
        public EDocumentType DocumentType { get; set; }

        private bool Validate()
        {
            if (DocumentType == EDocumentType.CNPJ && Number.Length == 14)
                return true;

            if (DocumentType == EDocumentType.CPF && Number.Length == 11)
                return true;

            return false;
        }
    }
}
