#include "game_service.h"
#include <Poco/Data/Common.h>
#include <Poco/Data/SQLite/Connector.h>
#include "game_database_session.h"

GameService::GameService()
{
}

GameService::~GameService()
{
}


bool GameService::initialize()
{
    try
    {
        std::cout << "registering database ..." << std::endl;
        if (registerDatabase() == true)
        {
            GameDatabaseSession::getInstance().test();
        }
    }
    catch (...)
    {
        std::cout << "An unknown exception occured when initialize game service. Aborted." << std::endl;
        return false;
    }

    return true;
}

void GameService::destroy()
{
    unregisterDatabase();
}

bool GameService::registerDatabase()
{
    Poco::Data::SQLite::Connector::registerConnector();
    return true;
}

void GameService::unregisterDatabase()
{
    Poco::Data::SQLite::Connector::unregisterConnector();
}