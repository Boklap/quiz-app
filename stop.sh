#!/bin/bash

folders=("rabbitmq" "redis" "services/UserService" "services/QuestionService" "services/QuizService" "services/ScheduleService" "services/QuizResultService")

for folder in "${folders[@]}"; do
  echo "🔧 Building and starting services in: $folder"
  (
    cd "$folder" || exit
    docker compose down
  )
done

echo "✅ Semua service telah distop!"
