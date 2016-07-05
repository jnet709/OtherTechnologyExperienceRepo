Example of uploading a file to Azure container and record its info into SQL Server database.
	
	/// <summary>
        /// Save file into azure storage
        /// </summary>
        /// <returns></returns>
        public override Task ExecutePostProcessingAsync()
        {

            // Upload the files to azure blob storage
            // only 1 file at a time.  If attaching many files, we pick the last file in the list.

            var fileData = FileData.LastOrDefault();
            if (fileData == null)
            {
                return base.ExecutePostProcessingAsync();
            }

            // Retrieve reference to a blob
            var blobStorage = _myAzureAccount.CreateCloudBlobClient();
            var container = blobStorage.GetContainerReference(_myContainerName);
            container.CreateIfNotExists(); // default access is private

            // new blob file: {Guid.fileExtension}
            var newFileName = GetLocalFileName(fileData.Headers);

            var blockBlob = container.GetBlockBlobReference(newFileName);
            blockBlob.Properties.ContentType = fileData.Headers.ContentType.ToString();
            // upload data to blob
            blockBlob.UploadFromFile(fileData.LocalFileName, FileMode.Open);


            // get file info to be saved in database
            File = new FileDetailsDataStoreModel
            {
                ContentType = blockBlob.Properties.ContentType,
                BlobName = blockBlob.Name,
                Size = blockBlob.Properties.Length,
                Url = blockBlob.Uri.AbsoluteUri,
                SessionId = SessionId,
                DataKey = DataKey,
                ApplicationId = ApplicationId,
                Name = Name,
                Preserve = Preserve,
                CreatedDate = CreatedDate,
                UpdatedDate = UpdatedDate
            };

            // Saved data store record info in database

            var now = DateTime.UtcNow;

            // now see if Adding or Replacing data store

            if (ExistingDataStore == null)
            {
                // ADDING
                var dataStore = new AccountFile()
                {
                    Name = File.Name,
                    BlobFileName = File.BlobName,
                    DataKey = File.DataKey,
                    Preserve = File.Preserve,
                    CreatedDate = now,  // important: mark both CreatedDate and UpdatedDate columns
                    UpdatedDate = now  // important: mark both CreatedDate and UpdatedDate columns
                };
                
            }

            // commit db
	// Context : Entity Framework db context
            Context.SaveChanges();

            return base.ExecutePostProcessingAsync();
        }
