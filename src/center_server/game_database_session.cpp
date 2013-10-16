#include "game_database_session.h"

GameDatabaseSession::GameDatabaseSession()
{
    _db_session = new Poco::Data::Session("SQLite", "./data/zeus_mud.db");
    _db_stmt = new Poco::Data::Statement(*_db_session);
}

GameDatabaseSession::~GameDatabaseSession()
{
    _db_session->close();

    SAFE_DELETE(_db_session);
    SAFE_DELETE(_db_stmt);
}